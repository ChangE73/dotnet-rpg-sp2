<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="html" indent="yes"/>
  <xsl:template match="/ArrayOfGetCharacterDto">
    <html>
      <body>
        <table border="1">
          <tr>
            <th>Name</th>
            <th>HitPoints</th>
            <th>Strength</th>
          </tr>
          <xsl:for-each select="GetCharacterDto">
            <tr>
              <td><xsl:value-of select="Name"/></td>
              <td><xsl:value-of select="HitPoints"/></td>
              <td><xsl:value-of select="Strength"/></td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
