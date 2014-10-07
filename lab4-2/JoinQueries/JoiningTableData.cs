// Fig. 22.24: JoiningTableData.cs
// Using LINQ to perform a join and aggregate data across tables.
using System;
using System.Linq;
using System.Windows.Forms;

namespace JoinQueries
{
   public partial class JoiningTableData : Form
   {
      public JoiningTableData()
      {
         InitializeComponent();
      } // end constructor

      private void JoiningTableData_Load( object sender, EventArgs e )
      {
         // Entity Framework DBContext
         BooksExamples.BooksEntities dbcontext =
            new BooksExamples.BooksEntities();

         // get authors and titles of each book they co-authored
         var authorsAndTitles =
            from book in dbcontext.Titles
            from author in book.Authors
            orderby book.Title1
            select new { author.FirstName, author.LastName,
               book.Title1 };

         outputTextBox.AppendText( "Authors and titles:" );

         // display authors and titles in tabular format
         foreach ( var element in authorsAndTitles )
         {
            outputTextBox.AppendText(
               String.Format( "\r\n\t{0,-10}\t {1,10} {2}",
                    element.Title1, element.FirstName, element.LastName  ) );
         } // end foreach


          //Get authors and titles and order by title, author name
          var authorsAndTitlesOrdered =
          from book in dbcontext.Titles
          from author in book.Authors
          orderby book.Title1, author.LastName, author.FirstName
          select new { author.FirstName, author.LastName, book.Title1 };

          outputTextBox.AppendText("\r\n\r\nTitles and Authors Ordered:");

          // display authors and titles in tabular format
          foreach (var element in authorsAndTitlesOrdered)
          {
                outputTextBox.AppendText(
                String.Format("\r\n\t{0,-10}\t {1,10} {2}",
                         element.Title1, element.FirstName, element.LastName));
          } // end foreach


         // get authors and titles of each book 
         //  group by titles, order by titles, author
          var authorsByTitleOrdered =
             from book in dbcontext.Titles
             orderby book.Title1
             select new
             {
                 Name = book.Title1,
                 Authors =
                    from author in book.Authors
                    orderby author.LastName, author.FirstName
                    select new  { author.LastName, author.FirstName }
             };

         outputTextBox.AppendText( "\r\n\r\nTitles grouped by author:" );

         // display titles written by each author, grouped by author
         foreach (var title in authorsByTitleOrdered)
         {
            // display author's name
            outputTextBox.AppendText( "\r\n" + title.Name + ":" );

            // display titles written by that author
            foreach ( var author in title.Authors )
            {
               outputTextBox.AppendText( "\r\n\t\t" + author.FirstName + " " + author.LastName);
            } // end inner foreach
         } // end outer foreach
      } // end method JoiningTableData_Load
   } // end class JoiningTableData
} // end namespace JoinQueries


/**************************************************************************
 * (C) Copyright 1992-2014 by Deitel & Associates, Inc. and               *
 * Pearson Education, Inc. All Rights Reserved.                           *
 *                                                                        *
 * DISCLAIMER: The authors and publisher of this book have used their     *
 * best efforts in preparing the book. These efforts include the          *
 * development, research, and testing of the theories and programs        *
 * to determine their effectiveness. The authors and publisher make       *
 * no warranty of any kind, expressed or implied, with regard to these    *
 * programs or to the documentation contained in these books. The authors *
 * and publisher shall not be liable in any event for incidental or       *
 * consequential damages in connection with, or arising out of, the       *
 * furnishing, performance, or use of these programs.                     *
 *************************************************************************/
