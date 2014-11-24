<?xml version = "1.0"?>
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
        <xsl:value-of select = "title"/>
      </h1>
      <h2 style = "color: blue">
        by
        <xsl:value-of select = "author/firstName" />
        <xsl:text> </xsl:text>
        <xsl:value-of select = "author/lastName" />
      </h2>

      <table style = "border-style: groove; background-color: wheat">
        <xsl:for-each select = "chapters//*">
          <xsl:sort select = "@pages" data-type = "number"
             order="ascending" />
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
        <xsl:value-of select = "name()" />
      </td>

      <td>
        ( <xsl:value-of select = "@pages" /> pages )
      </td>
    </tr>
  </xsl:template>

  <!-- match chapter -->
  <xsl:template match = "chapters/chapter">
    <tr>
      <td style = "text-align: right">
        Chapter <xsl:value-of select = "@number"/>
      </td>

      <td>
        <xsl:value-of select = "text()"/>
        ( <xsl:value-of select = "@pages"/> pages )
      </td>
    </tr>
  </xsl:template>

  <!-- match appendix -->
  <xsl:template match = "chapters/appendix" >
    <tr>
      <td style = "text-align: right">
        Appendix <xsl:value-of select = "@number"/>
      </td>

      <td>
        <xsl:value-of select = "text()" />
        ( <xsl:value-of select = "@pages"/> pages )
      </td>
    </tr>
  </xsl:template>
</xsl:stylesheet>