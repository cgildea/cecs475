##Chapter 9 - Introduction to LINQ and Generic Collection.

###Query an array using LINQ
```
      // create an integer array
      int[] values = { 2, 9, 5, 0, 3, 7, 1, 4, 8, 5 };

      // display original values
      Console.Write( "Original array:" ); 
      foreach ( var element in values )
         Console.Write( " {0}", element );

      // LINQ query that obtains values greater than 4 from the array
      var filtered =
         from value in values
         where value > 4
         select value;

      // use orderby clause to original values in ascending order
	  var sorted =
         from value in values
         orderby value
         select value;

      // sort the filtered results into descending order
      var sortFilteredResults =
         from value in filtered
         orderby value descending
         select value;
```
###Create an use a genericck List colletions
```
	  // filter a range of salaries using && in a LINQ query
      var between4K6K =
         from e in employees
         where e.MonthlySalary >= 4000M && e.MonthlySalary <= 6000M
         select e;

      // order the employees by last name, then first name with LINQ
      var nameSorted = 
         from e in employees 
         orderby e.LastName, e.FirstName 
         select e;

      // attempt to display the first result of the above LINQ query
      if ( nameSorted.Any() )
         Console.WriteLine( nameSorted.First() );
      else
         Console.WriteLine( "not found" );

      // use LINQ to select employee last names
      var lastNames =
         from e in employees
         select e.LastName;

      // use method Distinct to select unique last names
      Console.WriteLine( "\nUnique employee last names:" );
      foreach ( var element in lastNames.Distinct() )
         Console.WriteLine( element );

      // use LINQ to select first and last names
      var names =
         from e in employees
         select new { e.FirstName, Last = e.LastName };
```

###Query a generic List collection using LINQ
```
      // populate a List of strings 
      List< string > items = new List< string >();
      items.Add( "aQua" ); // add "aQua" to the end of the List
      items.Add( "RusT" ); // add "RusT" to the end of the List
      items.Add( "yElLow" ); // add "yElLow" to the end of the List
      items.Add( "rEd" ); // add "rEd" to the end of the List

      // convert all strings to uppercase; select those starting with "R"
      var startsWithR =
         from item in items
         let uppercaseString = item.ToUpper()
         where uppercaseString.StartsWith( "R" )
         orderby uppercaseString
         select uppercaseString;

      // display query results
      foreach ( var item in startsWithR )
         Console.Write( "{0} ", item );
```
##Chapter 22

You can query EDM mainly by three ways: 
1) LINQ to Entities 
```
	//Querying with LINQ to Entities
	 using (var objCtx = new SchoolDBEntities())
	{
	    var schoolCourse = from cs in objCtx.Courses
	                       where cs.CourseName == "Course1"
	                       select cs;
	    Course mathCourse = schoolCourse.FirstOrDefault<Course>();
	    IList<Course> courseList = schoolCourse.ToList<Course>();
	    string courseName = mathCourse.CourseName;
	}
```
2) Entity SQL 
```
    //Querying with Object Services and Entity SQL
    using (var objCtx = new SchoolDBEntities())
    {
        string sqlString = "SELECT VALUE cs FROM
		SchoolDBEntities.Courses
        AS cs WHERE cs.CourseName == 'Maths'";
        ObjectQuery<Course> course =
		objCtx.CreateQuery<Course>(sqlString);
        Course coursename1 = course.FirstOrDefault<Course>();
}
```
3) Native SQL.
```
	//Querying with native sql
	using (var objCtx = new SchoolDBEntities())
	{
	//Inserting Student using ExecuteStoreCommand
	            int InsertedRows = objCtx.ExecuteStoreCommand("Insert into
					Student(StudentName,StandardId) values('StudentName1',1)");
	            //Fetching student using ExecuteStoreQuery
	            var student = objCtx.ExecuteStoreQuery<Student>("Select *
					from Student where StudentName = 'StudentName1'", null).ToList();
	}
```
###Save Changes:
```
//Update entity using SaveChanges method
using (SchoolEntities ctx = new SchoolDBEntities())
      {
          var stud = (from s in ctx.Students
                      where s.StudentName == "Student1"
                      select s).FirstOrDefault();
          stud.StudentName = "Student2";
          int num = ctx.SaveChanges();
      }
```
Add and save single entity using DBContext which in-tern insert single row in database table.
```
	// create new Standard entity object
	var newStandard = new Standard();
	// Assign standard name
	newStandard.StandardName = "Standard 1";
	//create DBContext object
	using (var dbCtx = new SchoolDBEntities())
	{
	    //Add standard object into Standard DBset
	    dbCtx.Standards.Add(newStandard);
	    // call SaveChanges method to save standard into database
	    dbCtx.SaveChanges();
	}
```
###Delete
```
	using (var dbCtx = new SchoolDBEntities())
	{
	//if already loaded in existing DBContext then use Set().Remove(entity) to delete it.
	var newtchr = dbCtx.Teachers.Where(t => t.TeacherName == "New teacher4").FirstOrDefault<Teacher>();
	dbCtx.Set(Teacher).Remove(newtchr);
	//Also, you can mark an entity as deleted
	//dbCtx.Entry(tchr).State = System.Data.EntityState.Deleted;
	//if not loaded in existing DBContext then use following.
	//dbCtx.Teachers.Remove(newtchr);
	dbCtx.SaveChanges();
	}
```
###Add One-to-One Relationship Entity Graph using DBContext
```
  // create new student entity object
  var student = new Student();
  // Assign student name
  student.StudentName = "New Student1";
  // Create new StudentAddress entity and assign it to student entity
  student.StudentAddress = new StudentAddress() { Address1 = "Student1's Address1", 
  		Address2 = "Student1's Address2", City = "Student1's City",
	State = "Student1's State" };
  //create DBContext object
  using (var dbCtx = new SchoolDBEntities())
  {
  //Add student object into Student's EntitySet
  dbCtx.Students.Add(student);
  // call SaveChanges method to save student & StudentAddress into database
  dbCtx.SaveChanges();
```
###Add One-to-Many Relationship Entity Graph using DBContext
```
	//Create new standard
	var standard = new Standard();
	standard.StandardName = "Standard1";
	//create three new teachers
	var teacher1 = new Teacher();
	teacher1.TeacherName = "New Teacher1";
	var teacher2 = new Teacher();
	teacher2.TeacherName = "New Teacher2";
	var teacher3 = new Teacher();
	teacher3.TeacherName = "New Teacher3";
	//add teachers for new standard
	standard.Teachers.Add(teacher1);
	standard.Teachers.Add(teacher2);
	standard.Teachers.Add(teacher3);
	using (var dbCtx = new SchoolDBEntities())
	{
    dbCtx.SaveChanges();
	//add standard entity into standards entitySet
	dbCtx.Standards.Add(standard);
	//Save whole entity graph to the database
	}
```
###Add Many-to-Many Relationship Entity Graph using DBContext
```
	//Create student entity
	var student1 = new Student();
	student1.StudentName = "New Student2";
	//Create course entities
	var course1 = new Course();
	course1.CourseName = "New Course1";
	course1.Location = "City1";
	var course2 = new Course();
	course2.CourseName = "New Course2";
	course2.Location = "City2";
￼   var course3 = new Course();
    course3.CourseName = "New Course3";
    course3.Location = "City1";
    // add multiple courses for student entity
    student1.Courses.Add(course1);
    student1.Courses.Add(course2);
    student1.Courses.Add(course3);
    using (var dbCtx = new SchoolDBEntities())
    {
        //add student into DBContext
        dbCtx.Students.Add(student1);
        //call SaveChanges
        dbCtx.SaveChanges();
    }
```

###Update Entity using DBContext
```
Student stud ;
    // Get student from DB
    using (var ctx = new SchoolDBEntities())
    {
        stud = ctx.Students.Where(s => s.StudentName == "New Student1").FirstOrDefault<Student>();
	}
    // change student name in disconnected mode (out of DBContext scope)
    if (stud != null)
    {
        stud.StudentName = "Updated Student1";
    }
    //save modified entity using new DBContext
    using (var dbCtx = new SchoolDBEntities())
    {
   	//Mark entity as modified
    dbCtx.Entry(stud).State = System.Data.EntityState.Modified;
    dbCtx.SaveChanges();
}
```
As you see in the above code snippet, we are doing following steps:
	1. Get the existing student
	2. Change student name out of DBContext scope (disconnected mode)
	3. We pass modified entity into Entry method to get its DBEntityEntry object and then marking its state as Modified
	4. Calling SaveChanges to update student information into the database.

###Update One-to-Many Entities
```
	using (var ctx = new SchoolDBEntities())
	{
		//fetching existing standard from the db
	    Standard std = (from s in ctx.Standards
	        where s.StandardName == "standard3"
	        select s).FirstOrDefault<Standard>();
	    std.StandardName = "Updated standard3";
		std.Description = "Updated standard";
	   	//getting first teacher to be removed
	   	Teacher tchr = std.Teachers.FirstOrDefault<Teacher>();
		//removing teachers (enable cascading delete for the teacher)
	   	if (tchr != null)
	       ctx.Teachers.DeleteObject(tchr);
	    Teacher newTeacher = new Teacher();
	    newTeacher.TeacherName = "New Teacher";
	   	std.Teachers.Add(newTeacher);
	    std.Teachers.Add(existingTeacher);
	    ctx.SaveChanges();
	}
```
###Update Many-to-Many Entities
```
	using (var ctx = new SchoolDBEntities())
	{
	    Student student = (from s in ctx.Students
	        where s.StudentName == "Student3"s
	        select s).FirstOrDefault<Student>();
	    student.StudentName = "Updated Student3";
	 	Course cours = student.Courses.FirstOrDefault<Course>();
	    //removing course from student
	    student.Courses.Remove(cours);
		ctx.SaveChanges();
	}
```
###Delete One-to-One Entities
```
	using (var ctx = new SchoolDBEntities())
	{
		Student student = (from s in ctx.Students
	    	where s.StudentName == "Student1"
	    	select s).FirstOrDefault<Student>();
			StudentAddress sAddress = student.StudentAddress;
			ctx.StudentAddresses.DeleteObject(sAddress);
			ctx.SaveChanges();
	}
```
###Delete One-to-Many Entities
```
using (var ctx = new SchoolDBEntities())
{
    //fetching existing standard from the db
    Standard std = (from s in ctx.Standards
        where s.StandardName == "standard3"
        select s).FirstOrDefault<Standard>();
    //getting first teacher to be removed
    Teacher tchr = std.Teachers.FirstOrDefault<Teacher>();
//removing teachers
    if (tchr != null)
        ctx.Teachers.DeleteObject(tchr);
    ctx.SaveChanges();
}
```
###Delete Many-to-Many Entities
```
using (SchoolDBContext ctx = new SchoolDBContext())
{
	Student student = (from s in ctx.Students
        where s.StudentName == "Student3"
        select s).FirstOrDefault<Student>();
    Course cours = student.Courses.FirstOrDefault<Course>();
    //removing course from student
    student.Courses.Remove(cours);
    ctx.SaveChanges();
}
```

###SQL: priamary key, foreign key, one-to-many, rule of referential integrity, rule of integrity, insert, update, delete, where, order by and inner join.
```

```






Books database
ADO.NET Entity Data Model Class Library
Entity data model diagram
Using the Entity Data Model
Display data from a database table in a DataGridView
Display the result of a user-selected query in a DataGridView
Lamba expression
Retrieving data from multiple with LINQ
Address Book Case Study
Review the Entity Framework for database handout
Add, update, delete records (one-to-one, one-to-many, and many-to-many)


###Sorting with XSL (Lab 5, Problem 2)
#####Solution is underneath the blanks
```
<!-- Solution: sorting_byPage.xsl -->
<!-- Transformation of book information into XHTML -->

<xsl:stylesheet version = "1.0" xmlns = "http://www.w3.org/1999/xhtml"
xmlns:xsl = "http://www.w3.org/1999/XSL/Transform">

  <!-- write XML declaration and DOCTYPE DTD information -->
  <xsl:output method = "xml" omit-xml-declaration = "no"
  doctype-system = "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd"
  doctype-public = "-//W3C//DTD XHTML 1.1//EN"/>

  <!-- match document root -->
  <xsl:template match = "/">
    <html>
      <xsl:apply-templates/>
    </html>
  </xsl:template>

  <!-- match book -->
  <xsl:template match = "book">
    <head>
      <title>
        ISBN <xsl:value-of select = "@isbn"/> -
        <xsl:value-of select = "title"/>
      </title>
    </head>

    <body>
      <h1 style = "color: blue">
        <!--<xsl:value-of select ="title"/> -->
        <xsl:value-of select ="title"/>
      </h1>
      <h2 style = "color: blue">
        by
        <!--  <______________________ = _______________________=""/> -->
        <xsl:value-of select = "author/firstName"/>
        <xsl:text> </xsl:text>
        <!-- <______________________________________/> -->
        <xsl:value-of select = "author/lastName"/>
      </h2>

      <table style = "border-style: groove; background-color: wheat">
        <xsl:for-each select = "chapters//*">
          <!--  <xsl:sort select ="____________________" data-type = "number" -->
          <!--  _____________________________=""/> -->
          <!-- Changed sort by number of "pages" instead of chapter "numbers" by specs -->
          <xsl:sort select ="@pages" data-type = "number" order = "ascending"/>
          <xsl:apply-templates select = "."/>
        </xsl:for-each>
      </table>

      <p style = "color: blue">
        Pages:
        <xsl:variable name = "pagecount"
        select = "sum(chapters//*/@pages)"/>
        <xsl:value-of select = "$pagecount"/>
        <br />Media Type: <xsl:value-of select = "media/@type"/>
      </p>
    </body>
  </xsl:template>

  <!-- match frontMatter element; override default and explicitly -->
  <!-- do nothing as we handle the children separately -->
  <xsl:template match = "chapters/frontMatter" />

  <!-- match any front matter section -->
  <xsl:template match = "chapters/frontMatter/*">
    <tr>
      <td style = "text-align: right">
        <!-- <xsl:value-of select ="_____________________"/> -->
        <xsl:value-of select ="name()"/>
```








