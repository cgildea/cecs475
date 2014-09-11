using System;
using System.Collections;
// Fig. 12.13: Employee.cs
// Employee abstract base class.
public abstract class Employee : IPayable, IComparable
{
    // read-only property that gets employee's first name
    public string FirstName { get; private set; }

    // read-only property that gets employee's last name
    public string LastName { get; private set; }

    // read-only property that gets employee's social security number
    public string SocialSecurityNumber { get; private set; }

    // three-parameter constructor
    public Employee(string first, string last, string ssn)
    {
        FirstName = first;
        LastName = last;
        SocialSecurityNumber = ssn;
    } // end three-parameter Employee constructor

    // return string representation of Employee object
    public override string ToString()
    {
        return string.Format("{0} {1}\nsocial security number: {2}",
           FirstName, LastName, SocialSecurityNumber);
    } // end method ToString


    int IComparable.CompareTo(object C)
    {
        Employee temp = (Employee)C;
        if (!(this.LastName.Equals(temp.LastName)))
        {
            return this.LastName.CompareTo(temp.LastName);
        }
        else if (!(this.FirstName.Equals(temp.FirstName)))
        {
            return this.FirstName.CompareTo(temp.LastName);
        }
        else
            return this.getSSN() - temp.getSSN();

    }

    private class sortPaymentAscendingHelper : IComparer
    {
        int IComparer.Compare(object a, object b)
        {
            Employee e1 = (Employee)a;
            Employee e2 = (Employee)b;

            if (e1.GetPaymentAmount() > e2.GetPaymentAmount())
                return 1;

            if (e1.GetPaymentAmount() < e2.GetPaymentAmount())
                return -1;

            else
                return 0;
        }
    }

    private class sortPaymentDescendingHelper : IComparer
    {
        int IComparer.Compare(object a, object b)
        {
            Employee e1 = (Employee)a;
            Employee e2 = (Employee)b;

            if (e1.GetPaymentAmount() < e2.GetPaymentAmount())
                return 1;

            if (e1.GetPaymentAmount() > e2.GetPaymentAmount())
                return -1;

            else
                return 0;
        }
    }

    public static IComparer sortPaymentAscending()
    {
        return (IComparer)new sortPaymentAscendingHelper();
    }
    public static IComparer sortPaymentDescending()
    {
        return (IComparer)new sortPaymentDescendingHelper();
    }


    // Note: We do not implement IPayable method GetPaymentAmount here so
    // this class must be declared abstract to avoid a compilation error.
    public abstract decimal GetPaymentAmount();

    public abstract int getSSN();

} // end abstract class Employee

/**************************************************************************
 * (C) Copyright 1992-2009 by Deitel & Associates, Inc. and               *
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
 **************************************************************************/