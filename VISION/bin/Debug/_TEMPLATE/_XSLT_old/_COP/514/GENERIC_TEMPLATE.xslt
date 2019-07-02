<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:cac="urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2"
	xmlns:cbc="urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2"
	xmlns:ccts="urn:un:unece:uncefact:documentation:2"
	xmlns:clm54217="urn:un:unece:uncefact:codelist:specification:54217:2001"
	xmlns:clm5639="urn:un:unece:uncefact:codelist:specification:5639:1988"
	xmlns:clm66411="urn:un:unece:uncefact:codelist:specification:66411:2001"
	xmlns:clmIANAMIMEMediaType="urn:un:unece:uncefact:codelist:specification:IANAMIMEMediaType:2003"
	xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:link="http://www.xbrl.org/2003/linkbase"
	xmlns:n1="urn:oasis:names:specification:ubl:schema:xsd:Invoice-2"
	xmlns:qdt="urn:oasis:names:specification:ubl:schema:xsd:QualifiedDatatypes-2"
	xmlns:udt="urn:un:unece:uncefact:data:specification:UnqualifiedDataTypesSchemaModule:2"
	xmlns:xbrldi="http://xbrl.org/2006/xbrldi" xmlns:xbrli="http://www.xbrl.org/2003/instance"
	xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:xlink="http://www.w3.org/1999/xlink"
	xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsd="http://www.w3.org/2001/XMLSchema"
	xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
	exclude-result-prefixes="cac cbc ccts clm54217 clm5639 clm66411 clmIANAMIMEMediaType fn link n1 qdt udt xbrldi xbrli xdt xlink xs xsd xsi">
	<xsl:decimal-format name="european" decimal-separator="," grouping-separator="." NaN=""/>
	<xsl:output version="4.0" method="html" indent="no" encoding="UTF-8"
		doctype-public="-//W3C//DTD HTML 4.01 Transitional//EN"
		doctype-system="http://www.w3.org/TR/html4/loose.dtd"/>
	<xsl:param name="SV_OutputFormat" select="'HTML'"/>
	<xsl:variable name="XML" select="/"/>
	<xsl:template match="/">
		<html>
		
			<head>
				<title/>
				<style type="text/css">
					body {
					    background-color: #FFFFFF;
					    font-family: 'Tahoma', "Times New Roman", Times, serif;
					    font-size: 11px;
					    color: #666666;
					}
					h1, h2 {
					    padding-bottom: 3px;
					    padding-top: 3px;
					    margin-bottom: 5px;
					    text-transform: uppercase;
					    font-family: Arial, Helvetica, sans-serif;
					}
					h1 {
					    font-size: 1.4em;
					    text-transform:none;
					}
					h2 {
					    font-size: 1em;
					    color: brown;
					}
					h3 {
					    font-size: 1em;
					    color: #333333;
					    text-align: justify;
					    margin: 0;
					    padding: 0;
					}
					h4 {
					    font-size: 1.1em;
					    font-style: bold;
					    font-family: Arial, Helvetica, sans-serif;
					    color: #000000;
					    margin: 0;
					    padding: 0;
					}
					hr {
					    height:2px;
					    color: #000000;
					    background-color: #000000;
					    border-bottom: 1px solid #000000;
					}
					p, ul, ol {
					    margin-top: 1.5em;
					}
					ul, ol {
					    margin-left: 3em;
					}
					blockquote {
					    margin-left: 3em;
					    margin-right: 3em;
					    font-style: italic;
					}
					a {
					    text-decoration: none;
					    color: #70A300;
					}
					a:hover {
					    border: none;
					    color: #70A300;
					}
					#despatchTable {
					    border-collapse:collapse;
					    font-size:11px;
					    float:right;
					    border-color:gray;
					}
					#ettnTable {
					    border-collapse:collapse;
					    font-size:11px;
					    border-color:gray;
					}
					#customerPartyTable {
					    border-width: 0px;
					    border-spacing:;
					    border-style: inset;
					    border-color: gray;
					    border-collapse: collapse;
					    background-color:
					}
					#customerIDTable {
					    border-width: 2px;
					    border-spacing:;
					    border-style: inset;
					    border-color: gray;
					    border-collapse: collapse;
					    background-color:
					}
					#customerIDTableTd {
					    border-width: 2px;
					    border-spacing:;
					    border-style: inset;
					    border-color: gray;
					    border-collapse: collapse;
					    background-color:
					}
					#lineTable {
					    border-width:2px;
					    border-spacing:;
					    border-style: inset;
					    border-color: black;
					    border-collapse: collapse;
					    background-color:;
					}
					#lineTableTd {
					    border-width: 1px;
					    padding: 1px;
					    border-style: inset;
					    border-color: black;
					    background-color: white;
					}
					#lineTableTr {
					    border-width: 1px;
					    padding: 0px;
					    border-style: inset;
					    border-color: black;
					    background-color: white;
					    -moz-border-radius:;
					}
					#lineTableDummyTd {
					    border-width: 1px;
					    border-color:white;
					    padding: 1px;
					    border-style: inset;
					    border-color: black;
					    background-color: white;
					}
					#lineTableBudgetTd {
					    border-width: 2px;
					    border-spacing:0px;
					    padding: 1px;
					    border-style: inset;
					    border-color: black;
					    background-color: white;
					    -moz-border-radius:;
					}
					#notesTable {
					    border-width: 2px;
					    border-spacing:;
					    border-style: inset;
					    border-color: black;
					    border-collapse: collapse;
					    background-color:
					}
					#notesTableTd {
					    border-width: 0px;
					    border-spacing:;
					    border-style: inset;
					    border-color: black;
					    border-collapse: collapse;
					    background-color:
					}
					table {
					    border-spacing:0px;
					}
					#budgetContainerTable {
					    border-width: 0px;
					    border-spacing: 0px;
					    border-style: inset;
					    border-color: black;
					    border-collapse: collapse;
					    background-color:;
					}
					td {
					    border-color:gray;
					}</style>
				<title>e-Fatura</title>
			</head>
			
			<body style="margin-left=0.6in; margin-right=0.6in; margin-top=0.79in; margin-bottom=0.79in">
			
				<xsl:for-each select="$XML">
				
					<table style="border-color:blue; " border="0" cellspacing="0px" width="850"	cellpadding="0px">
						<tbody>
							<tr valign="top">
								<td width="40%">									 									
										
									<table align="center" border="0" width="100%">
										<tbody>
											<hr/>
											
										 
														
											
											<tr align="left">
												<xsl:for-each select="n1:Invoice">
												<xsl:for-each select="cac:AccountingSupplierParty">
												<xsl:for-each select="cac:Party">
												<td align="left">
												<xsl:if test="cac:PartyName">
												<xsl:value-of select="cac:PartyName/cbc:Name"/>
												<br/>
												</xsl:if>
												<xsl:for-each select="cac:Person">
												<xsl:for-each select="cbc:Title">
												<xsl:apply-templates/>
												<span>
												<xsl:text>&#160;</xsl:text>
												</span>
												</xsl:for-each>
												<xsl:for-each select="cbc:FirstName">
												<xsl:apply-templates/>
												<span>
												<xsl:text>&#160;</xsl:text>
												</span>
												</xsl:for-each>
												<xsl:for-each select="cbc:MiddleName">
												<xsl:apply-templates/>
												<span>
												<xsl:text>&#160;</xsl:text>
												</span>
												</xsl:for-each>
												<xsl:for-each select="cbc:FamilyName">
												<xsl:apply-templates/>
												<span>
												<xsl:text>&#160;</xsl:text>
												</span>
												</xsl:for-each>
												<xsl:for-each select="cbc:NameSuffix">
												<xsl:apply-templates/>
												</xsl:for-each>
												</xsl:for-each>
												</td>
												</xsl:for-each>
												</xsl:for-each>
												</xsl:for-each>
											</tr>
											<tr align="left">
												<xsl:for-each select="n1:Invoice">
												<xsl:for-each select="cac:AccountingSupplierParty">
												<xsl:for-each select="cac:Party">
												<td align="left">
												<xsl:for-each select="cac:PostalAddress">
												<xsl:for-each select="cbc:StreetName">
												<xsl:apply-templates/>
												<span>
												<xsl:text>&#160;</xsl:text>
												</span>
												</xsl:for-each>
												<xsl:for-each select="cbc:BuildingName">
												<xsl:apply-templates/>
												</xsl:for-each>
												<xsl:if test="cbc:BuildingNumber">
												<span>
												<xsl:text> No:</xsl:text>
												</span>
												<xsl:for-each select="cbc:BuildingNumber">
												<xsl:apply-templates/>
												</xsl:for-each>
												<span>
												<xsl:text>&#160;</xsl:text>
												</span>
												</xsl:if>
												<br/>
												<xsl:for-each select="cbc:PostalZone">
												<xsl:apply-templates/>
												<span>
												<xsl:text>&#160;</xsl:text>
												</span>
												</xsl:for-each>
												<xsl:for-each select="cbc:CitySubdivisionName">
												<xsl:apply-templates/>
												</xsl:for-each>
												<span>
												<xsl:text>/ </xsl:text>
												</span>
												<xsl:for-each select="cbc:CityName">
												<xsl:apply-templates/>
												<span>
												<xsl:text>&#160;</xsl:text>
												</span>
												</xsl:for-each>
												</xsl:for-each>
												</td>
												</xsl:for-each>
												</xsl:for-each>
												</xsl:for-each>
											</tr>
											<xsl:if
												test="//n1:Invoice/cac:AccountingSupplierParty/cac:Party/cac:Contact/cbc:Telephone or //n1:Invoice/cac:AccountingSupplierParty/cac:Party/cac:Contact/cbc:Telefax">
												<tr align="left">
												<xsl:for-each select="n1:Invoice">
												<xsl:for-each select="cac:AccountingSupplierParty">
												<xsl:for-each select="cac:Party">
												<td align="left">
												<xsl:for-each select="cac:Contact">
												<xsl:if test="cbc:Telephone">
												<span>
												<xsl:text>Tel: </xsl:text>
												</span>
												<xsl:for-each select="cbc:Telephone">
												<xsl:apply-templates/>
												</xsl:for-each>
												</xsl:if>
												<xsl:if test="cbc:Telefax">
												<span>
												<xsl:text> Fax: </xsl:text>
												</span>
												<xsl:for-each select="cbc:Telefax">
												<xsl:apply-templates/>
												</xsl:for-each>
												</xsl:if>
												<span>
												<xsl:text>&#160;</xsl:text>
												</span>
												</xsl:for-each>
												</td>
												</xsl:for-each>
												</xsl:for-each>
												</xsl:for-each>
												</tr>
											</xsl:if>
											<xsl:for-each
												select="//n1:Invoice/cac:AccountingSupplierParty/cac:Party/cbc:WebsiteURI">
												<tr align="left">
												<td>
												<xsl:text>Web Sitesi: </xsl:text>
												<xsl:value-of select="."/>
												</td>
												</tr>
											</xsl:for-each>
											<xsl:for-each
												select="//n1:Invoice/cac:AccountingSupplierParty/cac:Party/cac:Contact/cbc:ElectronicMail">
												<tr align="left">
												<td>
												<xsl:text>E-Posta: </xsl:text>
												<xsl:value-of select="."/>
												</td>
												</tr>
											</xsl:for-each>
											<tr align="left">
												<xsl:for-each select="n1:Invoice">
												<xsl:for-each select="cac:AccountingSupplierParty">
												<xsl:for-each select="cac:Party">
												<td align="left">
												<span>
												<xsl:text>Vergi Dairesi: </xsl:text>
												</span>
												<xsl:for-each select="cac:PartyTaxScheme">
												<xsl:for-each select="cac:TaxScheme">
												<xsl:for-each select="cbc:Name">
												<xsl:apply-templates/>
												</xsl:for-each>
												</xsl:for-each>
												<span>
												<xsl:text>&#160; </xsl:text>
												</span>
												</xsl:for-each>
												</td>
												</xsl:for-each>
												</xsl:for-each>
												</xsl:for-each>
											</tr>
											<xsl:for-each
												select="//n1:Invoice/cac:AccountingSupplierParty/cac:Party/cac:PartyIdentification">
												<tr align="left">
												<td>
												<xsl:value-of select="cbc:ID/@schemeID"/>
												<xsl:text>: </xsl:text>
												<xsl:value-of select="cbc:ID"/>
												</td>
												</tr>
											</xsl:for-each>
										</tbody>
									</table>
									<hr/>
								</td>
								<td width="20%" align="center" valign="middle">
									<br/>
									<br/>
									<img style="width:91px;" align="middle" alt="E-Fatura Logo"
										src="data:image/jpeg;base64,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"/>

									<h1 align="center">
										<span style="font-weight:bold; ">
											<xsl:text>e-FATURA</xsl:text>
										</span>
									</h1>
								</td>
								
									<td width="60%" align="center" valign="middle">
									<br/>
									<br/>
									<img  align="middle"  width="60%" alt="E-Fatura Logo"
										src="data:image/png;base64,Qk02OwEAAAAAADYAAAAoAAAATwEAAFAAAAABABgAAAAAAAA7AQAAAAAAAAAAAAAAAAAAAAAA////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////AAAA////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////AAAA////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////AAAA
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////AAAA////////////////////////
////////////////////////////////////////////////////9/f37+/31tfWvb7Gvb7GxsPG
xr7GxsPGvb7GxsPGxr7GxsPGvb7GxsPGxr7GxsPGvb7GxsPGxr7GxsPGvb691tPW5+fv//f/////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////AAAA////////////////////////////////////////////////
////////////////7+/v5+fvvb69paallJaUhIaEa21rc3Fza3Fzc3Fza3Fzc3Fza3Fzc3Fza3Fz
c3Fza3Fzc3Fza3Fzc3Fza3Fzc3Fza3Fzc3Fze4KElJKUnKKltba1zs/O//v/////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////7+vvtba1vbq9vbq9vbq9tbq9vbq9vbq9vbq9tbq9vbq9vbq9vbq9tbq9vbq9vbq9vbq9
tbq9vbq9tba15+Pn////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
AAAA////////////////////////////////////////////////////////7+/3vb69nJqcjI6M
e3l7c3Vze3V7c3V7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7hH2Ee3l7e3l7c3Vze3V7c3FzhIKEpaKl1tfe//v/////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////3tvee3l7c3Vze3l7
c3Vze3l7c3V7e3l7c3Vze3l7c3V7e3l7c3Vze3l7c3V7e3l7c3Vze3l7c3Fzc3VzzsvO////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////AAAA////////////////////
////////////////////////////7+/vvbq9jI6Me317c3Vzc3V7e3l7e3l7e3l7e317e3l7e32E
e3l7e317e3l7e32Ee3l7e317e3l7e32Ee3l7e317e3l7e32Ee3l7e317e317e317c3l7e32Ee3l7
e3l7c3Vzc3V7e4KEpaKlzs/O//v/////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////59/nc3Vze3l7e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e3l7e3l71tPW////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////AAAA////////////////////////////////////////////
zs/OjI6Ue3l7e3l7e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e3l7c3V7e32E
paKl5+fv////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////5+Pne317e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e3l71s/W////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////AAAA////////////////////////////////////9/P3tba1jIqMc3Vze3l7e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e317e3l7c3Vze3l7hIqMzsvO////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////5+Pne3l7e3l7
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e3l7e3l71tPW////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////AAAA////////////////
////////////////7+fvraqte3V7c3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7hH2Ee3l7e3l7e3l7e3V7hIKEzsvO////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////5+Pne32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7hH2Ee3l7e3l71s/W////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////AAAA////////////////////////////9+/3lJKUe3V7
e3l7e32Ee3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e32E
c3l7e317e3l7e3l7e317zsvO////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////5+Pne3l7e3l7e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e3l7e3l71tPW////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////AAAA////////////////////////////vb69e3l7e3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7hH2Ee3l7hH2Ee3l7hH2Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e317e3l7hH2Ee3l7e32Ee3l7e3l7hIKE
1tPW////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////5+Pne317
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e3l71s/W
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////AAAA////////////
////////////1tfWhIaMc3Vze317c3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e3V7lJaU7+/v////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////5+Pne3l7e3l7e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e3l7e3l71tPW////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////AAAA////////////////////7+/3paKle3l7e3l7
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7hH2Ee3l7
e3l7c3Vze3V7c3Vze3V7c3Vze32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7c3V7ra61////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////5+Pne32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7hH2Ee3l7e3l71s/W////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////AAAA////////////////////xsPGe3l7e3l7c3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e3l7e3l7e3l7jIqMlJaUlJKUlJKUlJKUlI6U
e3l7e3l7e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e3l7c3l7
e317c3VzjI6M3t/e////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////5+Pn
e3l7e3l7e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e3l7e3l7
1tPW////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////AAAA////////
////////////tbK1e3l7e3l7hH2Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e317e3l7e32Ee3l7e3V7paal5+Pn7+vv7+vv7+fv7+vv5+PnxsfGhIaMe32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee317e32Ee3l7e317c3VzxsPG////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////5+Pne317e3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e3l71s/W////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////AAAA////////////////7+vvnJqcc3Vze317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e32Ec3VzhIKEtba1
9/P3////////////////////////////3tfee32Ee3l7e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7c3FznJqc9/P3////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////5+Pne3l7e3l7e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e3l7e3l71tPW////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////AAAA////////////////5+PnjI6Me3l7e3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7hH2Ee3l7e3l7paal//v///////////v/////////////
////////////raqte3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7jIqM3uPn////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
5+Pne32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7hH2Ee3l7
e3l71s/W////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////AAAA////
////////////xsfGc3Vzc3l7e3l7c3l7e3l7e3l7e3l7c3l7e3l7e3l7e3l7c3l7e3l7e3l7e3l7
c3l7e3l7e3l7e3V7hIqM7+/v////////////////////////////////////////1tfWhIKEe3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e32Ee317zs/O
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////5+Pne3l7e3l7e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e3l7e3l71tPW////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////AAAA////////////////vba9c21ze3l7
e3l7e3l7e3l7e3l7e3l7e3l7e3l7e3l7e3l7e3l7e3l7e3l7e3l7e3l7e3l7e3l7hIaE1s/W////
//////////////////////////////////////////v/paate3l7e3l7hH2Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e3V7vbq9////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////7/P37+/v7+vv9+/37+vv7+/37+vv9+/37+vv7+/37+vv7+vv9/P3////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////7+vv9+/37+vv7+/37+vv9+/37+vv7+/37+vv9+/37+vv7+/3
//v/////////////////////////////////////////////////////////////////////////
////////////////////////////5+Pne3l7e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e3l7zs/W////////////////////////////////////////
//////v/7+/37+vv9+/37+vv7+vv7+/3////////////////////////////////////////////
//////////////////v/////9///////////////////////////////////////////////////
////////////////////9///////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////9///////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////AAAA////////////9/f3zsfOvba9vbq9vbq9vbq9vbq9vbq9vbq9vbq9
vbq9vbq9vbq9vbq9vbq9vbq9vbq9vbq9vbq9vbq91tPW//v/////////////////////////////
////////////////////3tfee317e3l7e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e317e317c3Fzra615+fn7+vv5+fn7+vv5+fn7+vv5+fn7+vv5+fn7+vv5+fn7+vv
5+fn7+vv5+fn7+fv9/P3////////////////////////////////////////////////////////
//////////////////////////////v/////////////7+/v7+vv1tvexsPGvbq9nJqcjIqMjI6M
jIqMjI6UjIqMjI6MjIqMjI6UjIqMjIqMhIaMnJ6lvb69xsPGzs/O7+vv//////////////v/////
//////////////////////////////////////////////////////v///////////v/zsvOxsPG
ra6tjIqMjIqMjI6UjIqMjI6MjIqMjI6UjIqMjI6MjIqMjI6UjI6Mra613t/e////////////////
//////////////v/9+/35+fn7+vv5+fn7+vv5+fn7+vv5+fn7+vv5+fn7+vv5+fn7+vv5+fn5+fv
7+vv1s/Wc3l7e3l7e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e3l7c3l71tPW//////////v/////////////////9/P3zsvOxsPGxsPGtbK1jI6MjI6MjIqMjI6U
hIqMnJqcvbq9xr7GxsvO7+vv5+fn//////////////////////////////////////////v/9///
9/f359vW59vW59vW79/W59vO59/W59vW79vW59vO59/W59vW79/W59vO59vW59vW79/W59vO59vW
59fW99/n//v3////////////9/////////////////////////////////v37+Pe59vO79vW59vO
59/W59vW79/W59vO59vW59vW79/W59vO59/W59vW79vW59vW79/W59vO59vO5+PW////////////
////////////////////////////////////9/v379/W59vO1tvO59/W59vW79/W59vO59/W59vW
79vW59vO59/W59vW79/W59vO59vW59vW79/W59vO59/W////////////////////////////AAAA
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////9/P3
pZ6le3V7hH2Ee3l7hH2Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
hIaElJKUlJKUlJKUlJKUlJKUlJKUlJKUlJKUlJKUlJKUlJKUlJKUlJKUlJKUlJKUjIqMxsfO////
////////////////////////////////////////////////////////////////////////////
////////////9+/3xsPGnJqclJKUjIqMc3Vzc3Fzc3l7e3l7e3l7e3l7c3l7e3l7e3l7e3l7c3l7
e3l7e3l7e3l7c3Fzc3V7c3FzhH2EjJKUvbq959/n////////////////////////////////////
////////////////////////////////////3t/nra61e3l7a3Fze3l7e3l7e3l7c3l7e3l7e3l7
e3l7c3l7e3l7e3l7e3l7c3l7e3l7c3V7jIqMtbK15+Pn//////////////////////v/tba1lI6U
lJKUlJKUlJKUlJKUlJKUlJKUlJKUlJKUlJKUlJKUlJKUlJKUlJKUlJaUjI6Me32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e3l7zs/W////////////
////////9/f3zsvOnJ6chIKEc3Fzc3Vzc3Vze3l7e3l7e3l7c3l7e3l7e3l7e3l7a21zhH2ElJKU
lJKUra6t3t/n//v/////////////////////9///////////////59/WlF1SnE0xpVU5pVU5pVU5
pVU5pVU5pVE5pVU5pVU5pVU5pVU5pVU5pVE5pVU5pVU5pVU5nFU5lEk5rXlr9+/v////////////
////////////////////////////////7+PepWlSnE0xpVE5pVU5pVU5pVU5pVU5pVU5pVE5pVU5
pVU5pVU5pVU5pVU5pVE5pVU5nFU5lFk5hFEppXFj9/Pv////////////////////////////////
////////////79/WrW1anE0xnFk5pVE5rVU5nFUxnFk5pVU5pVU5pVE5pVU5pVU5pVU5pVU5pVU5
pVE5pVU5pVU5pVU5pVU5////////////////////////////AAAA////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////vbq9c3Fze3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e32Ee317e3l7c3V7e3l7c3Vze3l7c3Vz
e3l7c3Vze3l7c3Vze3l7c3Vze3l7c3Vze3l7c3Vzc3Fztba1////////////////////////////
////////////////////////////////////////////////////////1tfWvbq9lJaUe3V7c3Fz
c3V7c3Vze32Ee3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e3l7
c3l7c3Vzc3FzjIqMtbK15+Pn////////////////////////////////////////////////////
////7+/vvb69hIKEc3Fzc3Vze317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e32Ec3Vzc3FzjIqMtbK15+Pn////////////9/f3paalc3Fze3l7c3Vze3l7c3Vze3l7c3Vz
e3l7c3Vze3l7c3Vze3l7c3Vze3l7c3Vze3l7e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317c3l71tPW////////////7+vvzs/OnJ6lc3Vzc3Vzc3l7
e317e3l7e317e3l7e317e3l7e317e3l7e3l7e3l7e3l7e3l7c3V7c3Vzc3VzhIaEra6t3tve////
////////////////////////////59fOhDQYjCgAjCgAjCwAjCgAlCwAjCgAjCwAjCgAlCwAjCgA
jCwAjCgAlCwAjCgAjCwAjCwAlCwAhBwApVlC7+ve////////////////////////////////////
////////59fOnEUhhCAAjCwAjCgAlCwAjCgAjCwAjCgAlCwAjCgAjCwAjCgAlCwAjCgAjCwAjCgA
lCwAjCwAhCQAlE0x/+/n////////////////////////////////////////////59vOnEkplCQA
jCwAnCgAlCgAjCwAjCwAlCwAjCgAjCwAjCgAlCwAjCgAjCwAjCgAlCwAjCgAjCwAjCgAlCwA////
////////////////////////AAAA////////////////////////////////////////////////
//////////////////////////////////v/9/P3//f/9/f3//f/9/f3//v///v/////////////
////////////////////////////zsvOc3FzhH2Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ec3Vzvbq9////////////////////////////////////////////////////
//////////////////////f/zs/OraatjIaMe3l7e3l7e3l7hH2Ee3l7e317e3l7hH2Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e317e3l7e32Ee317e317e3V7e3l7jIqM
tba17+vv////////////////////////////////////////////3t/enJqce317e3V7e3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e3l7c3Vz
nJac5+Pn//////////f/raate3l7e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e3l7zsvO////////zsfOjI6UhIKEc3Vze3l7e317e317e3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e3l7c3VzlJKU3tve////////////9///////////
////79vGlEEhjCwAlDQIjDQIlDQIjDQIlDQIjDQIlDQIjDQIlDQIjDQIlDQIjDQIlDQIjDQIlDgI
lDQAjCwApWFC9+/e////////////////////////////////////////////79vWlE0pjDAAjDQI
lDQIjDQIlDQIjDQIlDQIjDQIlDQIjDQIlDQIjDQIlDQIjDQIlDQIlDQAlDgIjCgApVU59+/n////
////////////////////////////////////////59vOlFU5jCwAlDgIlDQIlDQIhDgIjDgIjDQI
lDQIjDQIlDQIjDQIlDQIjDQIlDQIjDQIlDQIjDQIlDQIjDQI////////////////////////////
AAAA////////////////////////////////////////////////////////////////9/f31tfW
vbq9tba1lJKUjIaMjIqMjIqMjIaMjIaMlJKUtbK1xsPG7+fv9/f3//////////////v/////////
////xsfGc3Fze3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7c3V7tba1
//////////////////////////////////////////////////////v/////////////9+/3tbK1
e317e3l7e3V7e3l7e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e3l7c3VzjIaMtbK17+fv////////
////////////////////////zs/OhIaEc3Vze3l7c3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e3l7c3VzlJKU5+Pn////9/f3raat
c3Vze317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e3l7e3l71tPW////xsPG
e317c3Vzc3l7e3l7e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e3l7c3VzjI6M1tve//////////////v/////////79vOlDwhjCwIjDAIlDQI
jDAIlDQIjDAIlDQIjDAIlDQIjDAIlDQIjDAIlDQIjDAIlDQIjDQAlDgAhCgAnGVK7+ve////////
////////////////////////////////////59fOnE0pjCwAlDQIjDAIlDQIjDAIlDQIjDAIlDQI
jDAIlDQIjDAIlDQIjDAIlDQIjDQIjDgIjDQAjCwAnFE59+/v//////////v/////////////////
////////////////59vWlFE5lCgIlDQAlDQIlDAIlDQIlDAIlDQIjDAIlDQIjDAIlDQIjDAIlDQI
jDAIlDQIjDAIlDQIjDAIlDQI////////////////////////////AAAA////////////////////
//////////////////////////////////////v/3tveraalhH2EhH2Ee3V7e3l7e3l7e3l7e3V7
e3l7c3Vze3l7e3l7e3l7hIaEpaKlxsPG5+Pn9/f3////////////////zsvOc3FzhH2Ee3l7hH2E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ec3Vzvbq9////////////////////////
//////////////////////////////////////v/1tfWlJaUe3l7e3V7e3l7hH2Ee3l7hH2Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7hH2Ee3l7hH2Ee3V7e3V7lJaU7+vv////////////////////////7+vv
nJacc3V7e3l7e3l7hH2Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7hH2Ee3l7e317e3V7nJac5+fn//v/raqte3l7e3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e317zs/OzsvOe32Ee3l7e3l7e32Ee317e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e317
c3V7jJKU1t/e////////////////////59fOlDwpjCwIlDQQlDAIlDQQlDAIlDQQlDAIlDQQlDAI
lDQQlDAIlDQQlDAIlDQQlDAIlDQIlDQIjCgApV1K9+/n////////////////////////////////
////////////79vWnE0plCwAlDAIlDQQlDAIlDQQlDAIlDQQlDAIlDQQlDAIlDQQlDAIlDQQlDAI
lDQQlDQIlDQIlCgApVU59+/n////////////////////////////////////////////59vOpVE5
lCgAlDgIlDQIlDQQjDQInDQQlDAIlDQQlDAIlDQQlDAIlDQQlDAIlDQQlDAIlDQQlDAIlDQQlDAI
////////////////////////////AAAA////////////////////////////////////////////
////9/f31tfWpaalhIKEc3Vze3l7e3l7e3l7e3l7e317e3l7e3l7e3l7e3l7e3l7e317c3Vze3l7
e3V7e3l7hIaEraqt7+/3////////////xsfGc3Fze3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7c3Vztba1////////////////////////////////////////////////
////////7+vvtbK1hIKEc3Vze3l7e3l7e3l7e3l7e3l7e3l7e32Ee3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e3l7c3l7
e317e3l7e3l7e3l7e3V7lJaU7+vv//////////v/////9/f3tbK1e3l7e3l7e3l7e3l7e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e3l7c3V7nJqc1tfWraqtc3Vze317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e3l7e317nJqchIaEe3l7e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e3l7c3lzjJaU3tvW//////v/
////////59vOjDwhjDAIjDQIlDQIjDQIlDQIjDQIlDQIjDQIlDQIjDQIlDQIjDQIlDQIjDQIlDQI
lDQIlDQIjCQArV1K9+vn////////////////////////////////////////////59fOnE0pjCwA
lDQIjDQIlDQIjDQIlDQIjDQIlDQIjDQIlDQIjDQIlDQIjDQIlDQIlDQInDQInDQAlCgApVEx9+/n
////////////////////////////////////////////79vWnFExlCgAjDQAjDgIhDQIlDQIlDAI
lDQIjDQIlDQIjDQIlDQIjDQIlDQIjDQIlDQIjDQIlDQIjDQIlDQI////////////////////////
////AAAA////////////////////////////////////////////9/P3ta61hIKEc3V7e3l7e32E
e3l7e32Ee317e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7hH2Ee3l7e32Ee3l7e3l7c3V7paal7+/3
////////xsfOc3Fze32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ec3Vz
vbq9//////////////////////////////////////////////////////f/paKle317e3l7e32E
e317e32Ee3l7e32Ee317e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e317e3l7hH2Ee3l7e3l7
lJaU7+vv////////////1tPWhIKEe3l7e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee317e32Ee3l7e317c3V7nJqc
nJ6le3l7e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ec3Vze317
e317e32Ee317e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee317e32Ee3l7e317a3lzlI6U5+Pn////////////59vOlEEhjCwAlDQI
lDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDAIjCwArWFC9+vn////
////////////////////////////////////////79vWlE0plCwAlDQIlDQIlDQIlDQIlDQIlDQI
lDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQQlDAInDgIlCwApVU59+/n////////////////////////
////////////////////59vOpVUxlCwAlDQIlDAIjDgIlDQIlDQQlDQIlDQIlDQIlDQIlDQIlDQI
lDQIlDQIlDQIlDQIlDQIlDQIlDQI////////////////////////////AAAA////////////////
////////////////////////5+fnraqtc3Vze3l7e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e3l7c3VzpaKl9/P3////xsPGc3Fze3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7c3V7tba1////////////////////
////////////////////////////////tbK1e3l7e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7c3V7lJaU7+fv////9/f/paKl
e3V7e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317c3Vze32Ee317hIKEe3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317c3lzc317c3F7raat7/fv////////79vWlDwYlCwAlDAIlDQIjDAIlDQIlDAIlDQIjDAI
lDQIlDAIlDQIjDAIlDQIlDAIlDQIlDAIlDQIhCgArWVC9+vn////////////////////////////
////////////////59fOnE0pjCwAlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAI
lDQIjDAIlDQIjDQAjCwAnFEx9+/v////////////////////////////////////////////59vW
nFExlCwAjDAIlDAQjDQAlDgIlDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAI
lDQI////////////////////////////AAAA////////////////////////////////////1tPW
lJKUe3l7e3l7e3l7hH2Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e3l7c3V7raqt9/v/zsvOc3Fze32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ec3Vzvbq9////////////////////////////////////////////
////3t/ejIqMe3l7e3l7e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e3l7nJqc//f/1tfehH2Ec3l7hH2Ee317e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ec3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e4J7c317e3WEhHmE
ztPO////////59vOnEEhlCwAlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQI
lDQInDQQlDAIjCwApWVC9+/n////////////////////////////////////////////79vWnE0p
lCwAlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQQlDAIlDgIjCwApVU5
9+/n////////////////////////////////////////////59vWpVUxjCwAlDQQlDAIjDgIlDQA
lDQQlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQI////////////////////
////////AAAA//////////////////////////////v/zs/OjIaMc3Vze32Ee3l7e32Ee3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e3l7c3Vzraqttba1c3V7e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
c3Vztba1//////////////////////////////////////////////v/nJacc3Fze3l7e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e32Ec3l7hIKEtbK1paalc3Vze32Ec3V7e3l7e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e3l7
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e317e317c3mEe3V7lJqU9/f3////59vOlDwYlCwI
jDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAInDQIhCgArWVC9+vn
////////////////////////////////////////////59fOnE0pjCwAlDQIlDAIlDQIjDAIlDQI
lDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDQAjCwAnFEx9+/v////////////////////
////////////////////////79vWnFEpjCwAlDAIlDAQjDQAlDgIlDAIlDQIjDAIlDQIlDAIlDQI
jDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQI////////////////////////////AAAA////////////
////////////////vbq9hIKEe3V7e317e3l7e32Ee317e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e317e3l7e3l7e3l7hIKEe3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ec3Vzvbq9////////////////
////////////////////////9/f3vba9e3l7e3l7e3l7e317e3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee317e32Ee317e32Ee3l7hH2Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee317
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee317
hH2Ee317e32Ee3l7e32Ee3l7e317e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e317c317e32Ee3V7e317xsfG////59fOlDwhjCwAlDQIlDQIlDQIlDQIlDQIlDQI
lDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQInDQQlDAIjCwArWVC9+/n////////////////////////
////////////////////79vWnE0plCwAlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQI
lDQIlDQIlDQQlDAIlDgIjCwApVU59+/n////////////////////////////////////////////
59vOpVUxjCwAlDQQlDAIjDgIlDQAlDQQlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQI
lDQIlDQI////////////////////////////AAAA////////////////////////7+vvjI6Mc3Fz
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e3l7c3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7c3V7tba1////////////////////////////////////////
1s/We317e3l7e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317c3l7e3l7c3V7e3V7c3l7e3l7c3V7e32Ec3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317c3l7e3l7e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317c3l7e317e317e3l7
c3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317c31zc317c3mE
hHmEc3lznJ6c7+/379vWlDwYlCwAlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQI
lDAIlDQIlDAIlDQIhCgArWVC9+vn////////////////////////////////////////////59fO
nE0pjCwAlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDQAjCwA
nFEx9+/v////////////////////////////////////////////59vWnFExlCwAjDAIlDAQjDQA
lDgIlDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQI////////////////
////////////AAAA////////////////////////xr7Ge3l7hH2Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ec3Vzvbq9////////////////////////////////////////tbK1e3l7e3l7hH2Ee3l7hH2E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e3l7e3l7jIqMjI6U
lJKUlJKUjIaMc3Fze3l7e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e317e3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e3l7c3Vze3V7c3Vze3V7c3Vze3l7e3l7hH2Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e317c317e3mEe3l7e4J7e3l73tvn79/WnEEh
lCwAlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQInDQQlDAIjCwApWVC
9+/n////////////////////////////////////////////79vWnE0plCwAlDQIlDQIlDQIlDQI
lDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQQlDAIlDgIjCwApVU59+/n////////////////
////////////////////////////59vWpVUxjCwAlDQQlDAIjDgIlDQAlDQQlDQIlDQIlDQIlDQI
lDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQI////////////////////////////AAAA////////
////////////7+vvlJKUe3l7e3l7e3l7e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e32Ec3l7e317e3l7e317c3l7e317e3l7e317c3l7e3l7e3l7e32Ec3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7c3Vztba1////////////
////////////////////////3t/ejIaMc3Vze317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317c3l7e3l7e3l7paal3t/e7+vv5+fn7+vv1tvevb69lJqce3l7
c3l7e3l7e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317c3l7e3l7c3Vze3l7c3Vze3l7c3V7e3l7c3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e3l7c3l7c3V7lJKU
xsPGxsPGxsPGxsPGxsfGrbK1hIaEc3Vze3l7e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e317e317c3l7hHmEc31zc3FzxsvO79/WlDwYlCwIjDAIlDQIlDAIlDQIjDAI
lDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAInDQIhCgArWVC9+vn////////////////////
////////////////////////59fOnE0pjCwAlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAI
lDQIjDAIlDQIlDAIlDQIjDQAjCwAnFEx9+/v////////////////////////////////////////
////79vWnFEpjCwAlDAIlDAQjDQAlDgIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAI
lDQIlDAIlDQI////////////////////////////AAAA////////////////////vbq9e3l7e3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee317e32E
e3l7e3l7c3Vze3V7c3V7e3V7c3Vze317e3l7hH2Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ec3Vzvbq9////////////////////////////////////
zsvOc3Vze32Ee317e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e3l7jIqMzs/W9/f3//////////////////////////f/rbK1hH2Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e317e317hH2Ee3l7nJqcvb7G
xsPGxsPGtbK1hIKEhH2Ee3l7hH2Ee3l7hH2Ee3l7hH2Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7hH2Ee3l7hH2Ee3l7hIKEraat5+fn////////////////////////
1s/WnJacc3V7e3l7e317e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e317e317
hHmEhHmEe4J7c3lzpaat3s/GnEUhjCwAlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQI
lDQIlDQIlDQInDQQlDAIjCwArWVC9+/n////////////////////////////////////////////
79vWnE0plCwAlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQQlDAIlDgI
jCwApVU59+/n////////////////////////////////////////////59vOpVUxjCwAlDQQlDAI
jDgIlDQAlDQQlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQI////////////
////////////////AAAA////////////////5+PnlJKUc3Vze317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317c3l7e3l7e317e317c3VzhIKEjIqMjI6MjI6MjI6MjIqM
jIqMe317e3V7c3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7c3V7tba1////////////////////////////////7+/vnJqce3V7c3l7e3l7e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e3l7e32ExsfO////////////
////////////////////////////tba1e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e32EpaalzsvO//v/////////////////7+fvraqtjIqM
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317c3VzjIqMxsPG//v/////////////////////////////////7+vvnJ6ce3l7e3l7c3Vz
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3lze317e3mEhHmEc31ze3l7lJac1se9
lEEhlCwAlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIlDAIlDQIhCgA
rWVC9+vn////////////////////////////////////////////59fOnE0pjCwAlDQIjDAIlDQI
lDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDQAjCwAnFEx9+/v////////////
////////////////////////////////59vWnFExlCwAjDAIlDAQjDQAlDgIlDAIlDQIlDAIlDQI
jDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQI////////////////////////////AAAA////
////////////vb69c3Vze32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e317c3VzjIaMzs/O9/P37+/v9/P39+/39/f35+fnxsPGhIaMe3l7e3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ec3Vzvbq9////////
////////////////////////1tfee3l7e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e3l7hIKExsfO//v/////////////////////////////////////
////9/f/nJ6le3l7e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e3l7nJqc9+/3////////////////////////////////5+PnnJqce3l7hH2Ee3l7hH2Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7hH2Ee3l7e3l7tbK1//////v/
////////////////////////////////////5+fvlJKUc3V7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e317e317e3mEe3l7e4J7e317hIKMva6lnEUhlCwAlDQIlDQIlDQIlDQI
lDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQInDQQlDAIjCwApWVC9+/n////////////////
////////////////////////////79vWnE0plCwAlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQI
lDQIlDQIlDQIlDQIlDQQlDAIlDgIjCwApVU59+/n////////////////////////////////////
////////59vWpVUxjCwAlDQQlDAIjDgIlDQAlDQQlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQI
lDQIlDQIlDQIlDQI////////////////////////////AAAA////////////3t/ehIqMe3l7e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e32Ee3l7lJKU
zs/O////////////////////////////////1tfWhIaEe3l7e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7c3Vztba1////////////////////////////////
xsfGc3Fze32Ee3l7e3l7e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317c3l7e317
c3Fzpaat9/f3////////////////////////////////////////////////1tPWe317e3l7e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e3l7e3l7e3l7e3l73tve////////////
////////////////////////////1tfWhIKEc3Vze317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e3l7e3l7e3l7hIaE7+fv////////////////////////////////
////////////////zsvOhIKEc3V7e32Ee3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7hHmEc31ze317c32ErZ6UlDwYlDAIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQI
lDAIlDQIjDAIlDQIlDAInDQIhCgArWVC9+vn////////////////////////////////////////
////59fOnE0pjCwAlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQI
jDQAjCwAnFEx9+/v////////////////////////////////////////////79vWnFEpjCwAlDAI
lDAQjDQAlDgIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQI////////
////////////////////AAAA////////////vb69c3Fze3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7jIqM5+Pn////////////////////////
////////////////1tfehIKEe3l7e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ec3Vzvba9//////////////////////////////f/nJ6ce3l7e3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32ExsvO////////////////
////////////////////////////////////7+/3nJqcc3Vze32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7vbq9//v/////////////////////////////////////
////////tba1e3l7e3l7e317e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e3l7e3l7xsfG////////////////////////////////////////////////////////ra6t
e3l7e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e317e317hHmEhHmEe4J7e317e32E
jHlrlDgYlDAIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQInDQQlDAI
jCwArWVC9+/n////////////////////////////////////////////79vWnE0plCwAlDQIlDQI
lDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQQlDAIlDgIjCwApVU59+/n////////
////////////////////////////////////59vOpVUxjCwAlDQQlDAIjDgIlDQAlDQQlDQIlDQI
lDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQI////////////////////////////AAAA
////////////vbq9c3Fze3l7e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317c3l7e3l7tba1////////////////////////////////////////////9/f3nJqc
c3Vze317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7c3V7tba1////
////////////////////////9/P3lJaUc3Vze32Ee3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e3l7e317e3l7hIaE5+Pn////////////////////////////////////////
////////////////tbq9c3V7e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
c3l7e32E3tve////////////////////////////////////////////////3tvee317e3l7e3l7
e3l7e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e3l7c3VznJqc7+/v////////
////////////////////////////////////////////////3tvee317e3l7e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3lze317e3mEhHmEc31ze317e3mEhG1jjDQQlDAIlDAIlDQIjDAI
lDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIlDAIlDQIhCgArWVC9+vn////////////
////////////////////////////////59fOnE0pjCwAlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAI
lDQIjDAIlDQIlDAIlDQIjDAIlDQIlDQAjCwAnFEx9+/v////////////////////////////////
////////////59vWnFExlCwAjDAIlDAQjDQAlDgIlDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAI
lDQIlDAIlDQIjDAIlDQI////////////////////////////AAAA//////////f/lJKUe3l7e3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e3V7nJ6l9/P3
////////////////////////////////////////////////xsPGe3l7e3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ec3Vzvba9//v/////////////////////////
5+PnjIqMe3l7e3l7hH2Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e317
c3Vzra61//v/////////////////////////////////////////////////////////1tPWc3V7
e317e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7hH2Ee317e3l7e3173tve////////////
////////////////////////////////////3tvehH2Ee3l7hH2Ee317e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7hH2Ee3l7e3V7paal//f/////////////////////////////////
////////////////////////3t/ejIaMe3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e317e317e3mEe3l7e4J7e317e32EhG1jlDgYlDAIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQI
lDQIlDQIlDQIlDQIlDQInDQQlDAIjCwApWVC9+/n////////////////////////////////////
////////79vWnE0plCwAlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQQ
lDAIlDgIjCwApVU59+/n////////////////////////////////////////////59vWpVUxjCwA
lDQQlDAIjDgIlDQAlDQQlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQI////
////////////////////////AAAA////////9/P3jIqMc3l7e3l7e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317c3V7xsfG//////v/////////////////////
////////////////////////7+vvlJKUe3l7e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7c3l7nJqc9/P3////////////////////////zsvOe3l7c3l7e3l7e3l7e32E
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e3l7c3VzjIaM3tve////////////////
////////////////////////////////////////////zs/Oe3l7e3l7e3l7e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e32E1tfW////////////////////////////////////
////////////7+vvjI6Me3l7e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e3l7e3l7zsvO////////////////////////////////////////////////////////////
5+PnjIqMe3l7e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7hHmEc31ze317
c3mEhG1jjDQQlDAIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAI
nDQIhCgArWVC9+vn////////////////////////////////////////////59fOnE0pjCwAlDQI
lDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDQAjCwAnFEx9+/v////
////////////////////////////////////////79vWnFEpjCwAlDAIlDAQjDQAlDgIlDAIlDQI
jDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQI////////////////////////////
AAAA////////7+/vhIaMe3l7e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7hH2Ec3VzlJKU5+fn////////////////////////////////////////////////////
//f/ra6tc3VzhH2Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7hIKE
5+fn//////////////////////v/tbK1c3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7hH2Ee3l7e3l7jIaM59/n////////////////////////////////////////
////////////////////5+fnjIqMe3l7e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3173tve//////////////////////////////////////////////////v/raate3l7
hH2Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e3l71s/W////////
////////////////////////////////////////////////////////raqtc3FzhH2Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e317e317hHmEhHmEe4J7e317e32EhG1jlDgYlDAIlDQIlDQI
lDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQInDQQlDAIjCwArWVC9+/n////////
////////////////////////////////////79vWnE0plCwAlDQIlDQIlDQIlDQIlDQIlDQIlDQI
lDQIlDQIlDQIlDQIlDQIlDQIlDQQlDAIlDgIjCwApVU59+/n////////////////////////////
////////////////59vOpVUxjCwAlDQQlDAIjDgIlDQAlDQQlDQIlDQIlDQIlDQIlDQIlDQIlDQI
lDQIlDQIlDQIlDQIlDQIlDQI////////////////////////////AAAA////////xsfGe32Ee3l7
e3l7c3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e3l7vbq9////
////////////////////////////////////////////////////////xsfGc3Fze3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e3l7e3175+fn////////////////////
//f/jIqMe3l7e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3V7jIaM3t/e////////////////////////////////////////////////////////////9/f3
paKlc3Fze317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e32E1tfW////////
//////////////////////////////////////////v/paKle3l7e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e3V7jI6M5+Pn////////////////////////////////
////////////////////////////////ra6tc3Fze3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3lze317e3mEhHmEc31ze317e3mEhG1jjDQQlDAIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQI
lDAIlDQIjDAIlDQIlDAIlDQIlDAIlDQIhCgArWVC9+vn////////////////////////////////
////////////59fOnE0pjCwAlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQI
jDAIlDQIlDQAjCwAnFEx9+/v////////////////////////////////////////////59vWnFEx
lCwAjDAIlDAQjDQAlDgIlDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQI
////////////////////////////AAAA////////xsPGe3l7e317e3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7hH2Ee3l7e3l7jIqM5+Pn////////////////////////////
////////////////////////////////zsfOc3FzhH2Ee3l7hH2Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7hIKE5+fn////////////////////////tbK1e3l7e317e3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7hH2Ee3l7e3l7hIaE59/n////////////
//////////////////////////////////////////////////v/pZ6le3V7e317hH2Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e317e3173tve////////////////////////////////
//////////////////v/raate3l7hH2Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ec3Fzpaal//f/////////////////////////////////////////////////////////
////////tbK1c3FzhH2Ee3l7hH2Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e317e317e3mEe3l7e4J7
e317e32EhG1jlDgYlDAIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQI
nDQQlDAIjCwApWVC9+/n////////////////////////////////////////////79vWnE0plCwA
lDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQQlDAIlDgIjCwApVU59+/n
////////////////////////////////////////////59vWpVUxjCwAlDQQlDAIjDgIlDQAlDQQ
lDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQI////////////////////////
////AAAA////////vba9e3l7c3l7e3l7e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317c3VzlJKU5+fn////////////////////////////////////////////////////
////////xsfGc3Fze3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e3l7
e3l7zsvO////////////////////////zs/Oe3l7c3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317c3VzjIaM3t/e////////////////////////////////////
////////////////////////9/f3paKlc3Vze317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317c3l7e3171tfe//////////////////////////////////////////////////v/paKl
e3l7e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7c3VznJ6c//f/////
////////////////////////////////////////////////////////////ra6tc3Fze3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7hHmEc31ze317c3mEhG1jjDQQlDAIjDAI
lDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAInDQIhCgArWVC9+vn////
////////////////////////////////////////59fOnE0pjCwAlDQIlDAIlDQIjDAIlDQIlDAI
lDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDQAjCwAnFEx9+/v////////////////////////
////////////////////79vWnFEpjCwAlDAIlDAQjDQAlDgIlDAIlDQIjDAIlDQIlDAIlDQIjDAI
lDQIlDAIlDQIjDAIlDQIlDAIlDQI////////////////////////////AAAA////////hIKEe3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e317e3l7e3V7lI6U7+fv
////////////////////////////////////////////////////////////zsvOc3FzhH2Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e3l7tbK1////////////////
////////1tPWe3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e3l7jIaM59/n////////////////////////////////////////////////////////////
//f/pZ6le3V7e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3173tve////
//////////////////////////////////////////////v/raate3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e317c3FzpaKl//f/////////////////////////////
////////////////////////////////////tbK1c3FzhH2Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e317e317hHmEhHmEe4J7e317e32EhG1jlDgYlDAIlDQIlDQIlDQIlDQIlDQIlDQIlDQI
lDQIlDQIlDQIlDQIlDQIlDQIlDQInDQQlDAIjCwArWVC9+/n////////////////////////////
////////////////79vWnE0plCwAlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQI
lDQIlDQQlDAIlDgIjCwApVU59+/n////////////////////////////////////////////59vO
pVUxjCwAlDQQlDAIjDgIlDQAlDQQlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQI
lDQI////////////////////////////AAAA////////e4KEe317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317c3VzlJKU7+vv////////////////////////
////////////////////////////////////xsfGc3Fze3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317c3VznJqc9/P3////////////////////zs/Oe3l7e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3V7jIaM3t/e////////
////////////////////////////////////////////////////9/f3paKlc3FzhH2Ec3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e32E1tfW////////////////////////////
//////////////////////v/paKle3l7e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7c3VzpaKl//v/////////////////////////////////////////////////////
////////////ra6tc3Fze3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3lze317e3mEhHmE
c31ze317e3mEhG1jjDQQlDAIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAI
lDQIlDAIlDQIhCgArWVC9+vn////////////////////////////////////////////59fOnE0p
jCwAlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDQAjCwAnFEx
9+/n////////////////////////////////////////////59vWnFExlCwAjDAIlDAQjDQAlDgI
lDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQI////////////////////
////////AAAA////////vba9e3l7e317e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7hH2Ee3l7e3l7jIqM5+Pn////////////////////////////////////////////////
////////////zsvOc3FzhH2Ee3l7hH2Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e3l7hH2E9+/3////////////////////1s/We3l7e317e3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7hH2Ee3l7e3l7hIaE59/n////////////////////////////////
////////////////////////////9/P3nJace3V7e3l7hH2Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e317e3173tve//////////////////////////////////////////////////v/
raate3l7hH2Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7hH2Ec3FznJ6c9+/3
////////////////////////////////////////////////////////////9+/3nJqcc3VzhH2E
e3l7hH2Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e317e317e3mEe3l7e4J7e317e32EhG1jlDgYlDAI
lDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQInDQQlDAIjCwApWVC9+/n
////////////////////////////////////////////79vWnE0plCwAlDQIlDQIlDQIlDQIlDQI
lDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQQlDAIlDgIjCwApVU59+/v//////v/////////////
////////////////////////59vWpVUxjCwAlDQQlDAIjDgIlDQAlDQQlDQIlDQIlDQIlDQIlDQI
lDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQI////////////////////////////AAAA////////vb69
e3l7c3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e32Ee3l7e3V7
xsPG////////////////////////////////////////////////////////////xsfGc3Fze3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7hH2ExsPG////////
////////////1tPWhIKEc3l7e3l7e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7hH2Ec3VzjIqM3t/n////////////////////////////////////////////////////////
////1tfWhH2Ee3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317c3l7e3171tfe
//////////////////////////////////////////////////v/paKle3l7e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e3l7e3171tfW////////////////////////
////////////////////////////////////3tvehIKEe3l7e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7hHmEc31ze317c3mEhG1jjDQQlDAIjDAIlDQIlDAIlDQIjDAIlDQI
lDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAInDQIhCgArWVC9+vn////////////////////////
////////////////////59fOnE0pjCwAlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQI
jDAIlDQIlDAIlDQIlDQAlDAAjEEh1sO9//////////v/////////////////////////////////
59vOlFEplCwAlDAIlDQQjDQAlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQI
lDAIlDQI////////////////////////////AAAA////////xsPGe3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e317e3l7hH2Ec3Fzvb69////////////////////
////////////////////////////////////////zsfOc3Fze32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7hH2Ec3V7jIqM3t/n////////////////7+/3lJKUe3l7
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e317e317e3l7e317xsfO////
////////////////////////////////////////////////////////1tPWc3V7hH2Ee3l7e317
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3173tve////////////////////////
//////////////////////////v/raate3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7hH2Ee3l7e3V7zs/O////////////////////////////////////////////////
////////////3tvehIaMe3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e317e317hHmE
hHmEe4J7e317e32EhHFjjDgYlDAIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQI
lDQIlDQIlDQIlDQIjCgApWFC/+/e////9///////////////////////////////////////79vO
nE0plCwAlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQInDQIlDAI
ezAQrZaE////////////////////////////////////////////59vOnFU5lCgAnDQIjDQIlDQQ
lDAIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQI////////////////
////////////AAAA////////vb69e3l7e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7c3V7paKl9/f/////////////////////////////////////////
////////////////vbq9c3Fze3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e3l7e3l7paKl7/P3////////////9/P3nJqcc3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7c3V7ra6t////////////////////////////
////////////////////////////////xsvOe3l7e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e32E1tfW////////////////////////////////////////////////
//v/paKle3l7e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e3l7c3Vz
vbq9//v/////////////////////////////////////////////////////////xsfOe3l7e3l7
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3lze317e3mEhHmEc31ze317e32EhG1jjDQQ
lDAIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDQAlDgIjCgAjEEh
3se1////9///////////////////////////////9///////59fGnE0pjCwAlDQIjDAIlDQIlDAI
lDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDQIlDQIlDAIlDAIezAQvZ6M////////////////
////////////////////////////59vOlFExlCgAlDQAjDQIlDAInDQIlDQAlDQIlDAIlDQIjDAI
lDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQI////////////////////////////AAAA////////
xsPGe3l7e317e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
c3l7jI6U7+vv////////////////////////////////////////////////////7+/vnJqcc3V7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7hH2Ee3l7e3l7e317
xsfO//////////////f/nJ6ce3l7e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7hH2Ec3VznJqc7+/v////////////////////////////////////////////////
////9/f3raqtc3V7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e317e317
3tve//////////////////////////////////////////////////v/raate3l7hH2Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e3l7paKl//v/////////////////
////////////////////////////////////////rbK1c3V7e3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e317e317e3mEe3l7e4J7e317e32EnIp7lDwhlDAIlDQIlDQIlDQIlDQIlDQI
lDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIeygIzqqc////////////////////
////////////9///////////zq6ljDgQlDAIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQI
lDQIlDQIlDQIlDQIjDQIlDgIlCwIjDAQvZaE////////////////////////////////////////
////zrqljDwhlCwAlDgIjDQInDQQlDAIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQI
lDQIlDQIlDQI////////////////////////////AAAA////////vb69e3l7c3l7e3l7e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e3l7hIaE5+Pn////////////
////////////////////////////////////////3tvehIKEe3l7e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e32Ec3Vzc3V7hIqM1tPW////////////zsvO
c3Vze317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317c3l7e317e317
5+Pn////////////////////////////////////////////////////7+/3lJqce3V7e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317c3l7e3171tfe////////////////////
//////////////////////////////v/paKle3l7e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317c3VznJqc9/P3////////////////////////////////////////
////////////9/f3raqtc3Fze317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7hHmEc31ze317e32Eva6llDwYlDAIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAI
lDQIjDAIlDQIlDAInDAIjDAIeygIxqqU////////////////////////////9///9///////////
rYZzhCQAlDAAlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIjDQIjDgIjDQI
lDAIhCgIlFlC79vO////9///////////////////////////////////vZ6McyQAnDQIjDQIjDQI
lDAInDAIjDQIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQI////////////
////////////////AAAA////////3tvee32Ee32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e3l7vbq9////////////////////////////////////
////////////////raqte3l7e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e317e3l7e32Ee3l7e32EjIqMzsvO9/f/////1tPWc3V7e3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e317e3l7e32Ee3l7e317vb69////////////////////
////////////////////////////////zs/Oe32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3173tve////////////////////////////////////////////
//////v/raate3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
hH2Ee3l7vbq9//v/////////////////////////////////////////////////3t/nhIKEe3l7
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e317e317hHmEhHmEe4J7c3l7lJac1se9
nEUhjCwAlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQInDQQnCwInDQQ
hCwIrYJj//fv////9///9///7///9///9///9///////////9+fnnGFShCgAlDQIlDQIlDQIlDQI
lDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIjDQIlDQIlDAIlDAQeygQzq6c////////
//////////////////v/////////////tY5zhCQAlDQIjDQIjDQInDAQlDAIjDgIjDQIlDQIlDQI
lDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQI////////////////////////////AAAA////
////9/f3lJaUc3Vze317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317c3VzjI6M5+vv////////////////////////////////////////////3tvehIKEc3Vz
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e3l7e317paat5+PnxsPGc3Vze32Ee317e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317c3l7hIKE3t/e////////////////////////////////////////
////5+vvlJKUc3Vze317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e32E1tfW//////////////////////////////////////////////////v/paKle3l7e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e3l7e3l7e3l7e3l71tPW////////
////////////////////////////////////7+vvnJqce3l7e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3lze317e3mEhHmEc31zc3Vztba959fOlEEYlCwAlDAIlDQIjDAIlDQI
lDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIlDAInDAQlDQIjDQIczAIrYpr59/W////9///
9///9///////////////7+fenGlaeygQlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQI
jDAIlDQIlDAIlDQIlDAIlDQIjDQIlDQIjDAIhCgIrXFa79/W///3////////////////////////
////xraljEkpjCwAlDQIhDQAjDQQnCwInDQIhDQAjDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQI
lDAIlDQIjDAIlDQI////////////////////////////AAAA////////////tba9c3V7e3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ec3V7raqt7+/3
////////////////////////////////////9/P3nJ6lc3V7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e3l7c3VzlI6U
jI6Me32Ee317e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ec3V7tbK19/f3//////////////////////////////////////v/ra61c3Vze3l7e3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e317e3173tve////////////////
//////////////////////////////////v/raate3l7hH2Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7hH2Ee317e3l7lJKU7+fv////////////////////////////
////////7+vvnJ6lc3Vze3l7hH2Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e317
e317e3mEe3l7e4J7c3Fz1tfe79/WlEEhlCwAlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQI
lDQIlDQIlDQIlDQIlDQQlDAIlDQIjDgAjDgIhDAIlFlCxqKM//fv///39+ve79/W1rKltZJ7nGlK
eywIlDQQlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQInDQQlDAI
lDQIjDQIlDgIlDAIjDQQlFk5vZ6E79/O//vv///39+vn7+Pe1r6ttY5zhEUpeygInDQQlDQAjDQI
jDAQnDAQlDQIjDgIjDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDAI////////
////////////////////AAAA////////////xsfOc3Vze317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317c3VznJ6c1tPW////////////////////
////////9/P3ta61e3l7e3l7e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e32Ee3l7e3l7c3V7e3l7e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e317nJqczs/O////
////////////////////////3tveraqte317e3l7e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317c3l7e3171tfe////////////////////////////////////////
//////////v/paKle3l7e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e3l7paKl59/n////////////////////////9/P35+fnnJqcc3V7c3l7e3l7
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7hHmEc3lzjIqM3uPn
79/WlDwYlCwIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIjDAIjDQI
jDQAlDgAlDgAnDQIhCQAhDQYrXVatYpzlFk5lE0xjDgYhCwIhCwAlDQIlDQAlDQIjDAIlDQIlDAI
lDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAInDAQlDAIjDgIjDQAnDQIlDAIhCwI
ezAQlFExpXVavYpzlFlClE05jDwYjDAIjCwAlDQQlDAIlDgIhDQIjDQQnCwIlDQIhDQAlDQIjDAI
lDQIlDAIlDQIjDAIlDQIlDAIlDQIjDQAlDQIlDAIlDwY////////////////////////////AAAA
////////////5+PnlI6Ue3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee317e32Ee3l7hH2EpaKlxsPGvb69xr7Gvb69xr7Gtba1lJaUc3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e3l7c3V7e32EnKKl5+Pn9/P39/P39/P35+Pnpaat
hIKEe3l7e3l7e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3173tve//////////////////////////////////////////////////v/raate3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee317e3l7
hIaEra6txsPGxr7Gvb69xsPGra6tjI6UhIKEe3l7e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e317e317hHmEhHmEc3lznJ6c9/f/79vOnEEhjCwAlDQIlDQIlDQI
lDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIjDQIlDQIlDQIlDQIlDQInDQQjDAI
jDAIjDAIjCwIjCgAlDAIjDAIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQI
lDQIlDQIlDQIlDQIlDQIlDQIlDAIlDQIlDQIlDQIlDQInDQQlDQIjDAIhCgAjDAIjDAIjCwIjCgA
lDAIlDAInDQIlDQIlDQQlDQIlDQIlDQInDQQlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQI
lDAIlDgIlDQIlDAQvY5z////////////////////////////AAAA////////////9/f3paKlc3Vz
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e3l7c3Vze3l7c3l7e3l7c3l7e3l7c3l7e3l7c3l7e3l7e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317c3Vze3l7hIaEjIqMhIaEjIqMhIKEe3l7c3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e32E1tfW////////////
//////////////////////////////////////v/paKle3l7e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317c3l7e317c3l7e3l7c3Vze3l7e3l7e317c3l7
e3l7c3l7e3l7e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e317e317e3mEe3V7c31zzs/O////79fOlDwYlCwAlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAI
lDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAAlDAIlDAIlDQIjDAIlDQI
lDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAI
lDQIlDAIlDQIjDAIlDQIlDAIlDQIlDAIlDQIlDAAlDAIjDAAlDQIlDAIlDQIjDAIlDQIlDAIlDQI
jDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIlDAIlDQIjDQIlDQIhCwIxpqM////
////////////////////////AAAA////////////////1tPWe32Ee3l7e3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e3l7e3l7e3l7
e3l7e3l7e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e3l7c3l7e3l7e3l7e3l7e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e317e3173tve////////////////////////////////////
//////////////v/raate3l7hH2Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7hH2Ee317hH2Ee3l7e317e3l7e3l7e3l7e32Ee3l7hH2Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e317e317e32Ee3V7nKKc9/P3
////59fOnDwhlCwAlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQI
lDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQI
lDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQI
lDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQI
lDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDgIjDAIjDwh3r6t////////////////////////////
AAAA////////////////9/f3paatc3Fze317c3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317c3l7e32Ec3l7e32Ee317e3l7e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e3l7e3l7e3l7e3l7
e32Ee3l7e3l7e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e32Ec3l7e317e3l7e32Ec3l7
e317e3l7e3l7e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e3l7e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317c3l7e3171tfe//////////////////////////////////////////////////v/paKle3l7
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
c3l7e32Ee3l7e317e3l7e317e3l7e3l7e3l7e3l7e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e317e317c3V7hHmExsvG////////79vOlDwYlCwIjDAIlDQI
lDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAAlDQIjDAIlDQIjDAI
lDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQI
jDAIlDQIlDAIlDQIjDAIlDQIjDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAI
lDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQI
jDAIlDQIjDQIjDAIhEUp/+/n////////////////////////////AAAA////////////////////
1tfWhIaEc3V7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e317e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee317e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee317e32Ee3l7e32Ee317hH2Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e3l7e317hIKEe3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3173tve////////
//////////////////////////////////////////v/raate3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e317e317e32Ee3l7e317e3l7e32Ee3l7
e32Ee3l7e32Ee317e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e4J7c317e3F7nJKc9/f3////////79vOnEEhjCwAlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQI
lDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDAIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQI
lDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQI
lDQIlDQIlDQQjDAIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQI
lDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIjDgIlDQIhCwIpXlj//v3
////////////////////////////AAAA////////////////////7+/3lJKUc3Fzc3l7e3l7e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e32Ee3l7e317e3l7e3l7e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7c3V7e4KEvbq9lJaUe3l7e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e32E1tfW////////////////////////////////
//////////////////v/paKle3l7e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e317c3l7e3V7zsfO////
////////79vWlDwYlCwAlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQI
jDAIlDQIjCwAlDAIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAI
lDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDAIjDAIlDQIjDAIlDQI
lDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAIlDQIlDAIlDQIjDAI
lDQIlDAIlDQIjDAIlDQIlDAIlDQIjDQIlDgIlDAIhCwQxqaU////////////////////////////
////AAAA////////////////////////1tPWhIaEe3l7e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e3l7e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee317e3l7hIaE
xr7GjIqMe3l7e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e3l7
e32EzsvO9/f3paate3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e317e3173tve//////////////////////////////////////////////////v/raat
e3l7hH2Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e317c3lznJal//P/////////////79vOnEEhlCwAlDQI
lDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQQjDAIlDQIlDQI
lDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQI
lDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDAIlDAIlDQIlDQQlDQIlDQIlDQIlDQIlDQIlDQIlDQI
lDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQIlDQI
lDQIlDQIjDQIlDAInE0x79/W////////////////////////////////AAAA////////////////
//////////v/1tPWhIaEc3V7e3l7e317e3l7e3l7e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e3l7e3l7e32EhIKEe3l7e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317c3l7jIqM3t/evbq9c3Vze3l7e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e3l7e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e32Ee3l7e317e3l7e317c3l7c3V7lJaU1s/W//v///v/nJ6ce3l7e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317c3l7e3171tfe////
//////////////////////////////////////////////v/paKle3l7e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317c3l7e3l7e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317c3VzjJKU3tve////////////////79vOlDwhlCwIjDAIlDQIjDQIlDQIjDQIlDQIjDAI
lDQIjDQIlDQIjDAIlDQIjDAIlDQIjDAIlDAInEUhrWVChCwAlDAIlDAIlDQIlDAIlDQIlDAIlDQI
jDQIlDQIjDQAlDQIlDQAlDQIjDAAlDQIlDAIlDQIlDAAlDQIlDAIlDAIlDAIlDQIjDQIlDQIjDQA
lDQIjCwAlEUhpV0xjDQIjDAAlDQIlDAIlDQIlDAIlDQIlDAAlDQIjDQIlDQIjDQAlDQIlDAIlDQI
jDAAlDQIjDQIlDQIjDQIlDQIjDQIlDQIjDQAlDQIlDAIlDQIjDAIlDQIjDQIlDgQhCAArXFa9/Pn
////////////////////////////////AAAA////////////////////////////////1tPWjIaM
e3l7e3l7hH2Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e317e3l7e3l7pZ6lvba9c3VzhH2Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e317e317e3l7hIaM5+fv//v/nJace3V7e317e317hH2Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e317e3l7hH2Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee317
e3l7e317hH2Ee3V7e3V7lJaU7+vv//////////f/paKle3l7hH2Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3173tve////////////////////////////
//////////////////////v/raate3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3V7lJKUlJKUe3l7e317hH2Ee317e32Ee317e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7hH2Ee3l7e317e3l7hH2Ec3FzjJKU1t/e////////
//v/////////59vOlEEpjCwAlDQIlDQIlDgIlDQIlDgIlDQIlDQIlDQIlDgIlDQIlDQIlDQIlDQI
lDQIlDQIjCgArWFC59e9nG1ShCgIlDAQlDQIlDQInDAInDQQlDQIlDgIjDQIlDgIlDQAlDgIjDQA
lDgIjDQIlDgIjDQIlDgIlDQInDQQlCwQlDAQjDQIjDgIhDgIjDgIlDAAhDAIrYpz79vOpXlaeywA
jDAAnDQQlDAInDAQlDQInDQIjDQIjDgIjDQIlDgIlDQInDQInDAInDQIlDQIlDgIjDQIlDgIlDQI
lDgIjDgAlDgIlDQIlDAQlDAInDQQlDQIlDQIhCgIjEEp1se1////////////////////////////
////////AAAA////////////////////////////////////1tPWhIaEc3V7c3Vze32Ee3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e3l7e3173t/ezsvOc3Fze3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317c3V7
jIqM3uPn////1s/WhIKEc3Vze317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e3l7e3l7e3l7e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e3l7e3l7e3l7c3Vze317pZ6l7+fv
//////////////v/nJ6ce3l7e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e32E1tfW//////////////////////////////////////////////////v/
paKle3l7e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7c3Vzpaal5+Pn
nJqce3l7e3l7hH2Ee3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317c3FzlI6U3t/e//////////////v/////////79vOlDwhlCwI
lDAIlDQIlDAIlDQIlDAIlDQIlDAIlDQIlDAIlDQIlDAIlDQIlDAIlDQIlDAIjCgAnFVC//vv7+PW
pW1ShCwIlDQIjDQAlDQIjDQIlDQIjDAIlDQIlDAInDAIlDAIjDQIjDQIjDQIjDQIjDQIjDQIlDQI
jDAIjDQQjDAIlDQIlDQAlDQIjDAIeywIpXFS9+/v////9+venHlahDwYhCwAlDAIlDQIlDQIjDQI
jDQIjDAIlDQIlDAInDQInDAInDAInDAInDQIlDQIlDQIlDAInDQIlDAIlDQIjDAIlDQIjDQIjDgI
lDQInDQIjCgAeyQItZKE//////v3////////////////////////////////AAAA////////////
////////////////////////////1tPWhIaMe3V7e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3V7ra6t////zsfOc3FzhH2E
e3l7hH2Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e3l7hIqM5+Pn////////xsfGlI6U
c3Vze317e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ec3V7e3l7e3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e3l7c3VzjIaMxsPG9/P3//////////////////v/pZ6le3l7
hH2Ee3l7hH2Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e317e3173tve
//////////////////////////////////////////////////v/raate3l7hH2Ee3l7e32Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32E
e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ec3VzpaKl//v/7+vvnJqce3V7e3l7hH2Ee3l7
e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7hH2Ee3l7hH2Ee3l7e3l7
c3VzlJKU3t/e////////////////////////////79vGnEEpjCwIlDQQjDQIlDQQlDQIlDQQjDQI
lDQQlDQIlDQQjDQIlDQQlDQIlDQQjDQIlDQQjCgInFlK7+/n////9+PWpXFSeywAjDQAjDQAlDgI
lDQInDQQnDAInDAQlDAQlDAQlDAIlDQQlDAInDQQlDAInDQQlDAIlDQQhDgIjDgInDQArTAInCwI
hCwQhE0x59PG//////////////f3xqqclFExhDAIlDQIjDAIlDQQlDAInDAQnDAInDQIlDQIlDQI
lDAIlDQQjDAIlDQQlDQIlDQQlDAInDQQlDAQlDQQlDQIlDgIjDgIlDQIhCwAlEUpvZ6M9+vn////
////////////////////////////////////AAAA////////////////////////////////////
//////v/1tfetba1jIqMe3l7e3l7c3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317c3l7e3l7c3l7paKl7+/v////xsPGc3Fze3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317c3VzjIqM3t/e////////////3tvelI6Ue3l7e317e3l7e317e3l7
e317e3l7e317e3l7e317e3l7e317e3l7e3l7lJaUraqte317e3l7c3Vze3l7e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e3l7c3Vz
e3l7hIaEta615+Pn//////////////////////////v/nJ6ce3l7e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317c3l7e3171tfe////////////////////////
//////////////////////////v/paKle3l7e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7
e317e3l7e317e3l7e3V7paKl//f/////7+/vtbK1e3l7e3l7e32Ee3l7e317e3l7e317e3l7e317
e3l7e317e3l7e317e3l7e317e3l7e317e3l7e317e3l7e3l7c3VzlI6U3t/e////////////////
////////////////79vOlDwhjDAIjDQIlDQIjDQIlDQIjDQIlDQIjDQIlDQIjDQIlDQIjDQIlDQI
jDQIlDQIjDQAjCgApVlC7/Pv9///////7+fWtZZ7hEEYjDQIjCwAnDAInDAIpTAIlDAIjDQIhDQI
jDQIjDQIlDQIlDAIlDQIlDQIlDQIjDQIjDgIlDQAnDAIlCgAjDAYnG1a3su9//v3//v/9/v/////
////////59fGvZqEhEEhjCgIlCwInCwQnCwInDAIjDQAjDgIhDgAjDgIhDQIjDgIhDQIjDQIjDQI
jDgIjDAIjDQQjDAInDQInDAAlDAAezAInHFS1sO1////////////////////////////////////
////////////AAAA////////////////////////////////////////////////////7+/3vb69
jI6MhH2Ec3V7e317e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e3l7c3Vze32EjI6M
vba99+/3////////xsfGa21re3l7e3V7e3l7c3Vze3l7c3V7e3l7c3Vze3l7c3V7e3l7c3Vze3l7
c3V7e3l7c3Vze3l7c3V7e3l7c3Vze3l7c3V7e3l7c3Vze3l7c3V7e3l7c3Vze3l7c3V7e3V7c3V7
c3V7hIKE59/n////////////////9/P3tbK1e317e3l7c3Vze3l7e3l7hIKEe3l7hH2Ee3l7e317
e3l7e32Ec3V7ra6t////59/nraqtjIqMe3l7e3l7c3V7e32Ee317e32Ee3l7e32Ee3l7e32Ee3l7
e317e3l7e32Ee3l7e32Ee3l7e32Ee3l7e3l7c3Vze3V7e3l7jI6Mtba17+fv//v/////////////
////////////////9/f3nJqcc3Fze3l7e3V7e3l7c3Vze3l7c3V7e3l7c3Vze3l7c3V7e3l7c3Vz
e3l7c3V7e3l7c3Vze3V7c3V73tfe////////////////////////////////////////////////
//v/paKlc3Fze3V7c3Vze3l7c3V7e3l7c3Vze3l7c3V7e3l7c3Vze3l7c3V7e3l7c3Vze3l7c3V7
e3l7c3Vze3l7c3V7e3l7c3Vze3l7c3V7e3l7c3Vze3l7c3V7e3l7c3Vze3l7c3V7e3l7a21rpZ6l
9/f3////////////xsPGhIKEc3Fze3V7e3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7e32Ee3l7
e32Ee3l7e317e3V7e3l7hIKEta613t/e////////////////////////////////////59fGhDQY
hCQAjCwIjCgAjCwAjCgAjCwIjCgAjCwAjCgAjCwIjCgAjCwAjCgAjCwIjCgAjDAAhCQApVk57/Pv
////////////////7+PetY57jEUphCQIlCgIlDAInDgIlDgAjDwAjDgAjDgIjDQIlDQIjDQIlDgI
jDgIlDgIlDAAlCwIhCwIhEEhpX1r//Pv////////////////////////////////////1r61pWlK
hDAQhCgIlCwIlCwAnDgIlDQAlDgIjDQAlDgIlDQIlDgIlDQIlDQIlDQIlDQIhDQIjDAIjCwAlDQI
hDgYrYJz9+vn////////////////////////////////////////////////////AAAA////////
////////////////////////////////////////////////////7+vvvbq9lJacc3l7c3Vzc3Vz
e3V7c3Vzc3V7c3Vzc3V7c3Vze3l7c3Fzc3V7e4KElJaUvbq97+fv////////////////zs/OjIqM
lJKUlJKUjJKUlJKUjJKUlJKUjJKUlJKUjJKUlJKUjJKUlJKUjJKUlJKUjJKUlJKUjJKUlJKUjJKU
lJKUjJKUlJKUjJKUlJKUjJKUlJKUjJKUlJKUjJKUlJKUjJKUlJKUjI6MnJqc5+fn////////////
////////9/P3xsPGpaaljI6Ue317c3Vzc3Vze3l7e3l7e317c3Vze3l7c3Fzc3Fzpaal////////
//v/3tvetba9nJqcjIaMa3Fzc3Vzc3Vze3V7c3Vzc3V7c3Vzc3V7c3Vzc3V7c3Vze3V7c3Fzc3V7
c3Fze3l7jIqMlJKUjI6Mtba15+fn//////////////////////////////////////////f/raqt
lJKUlJKUlJKUjJKUlJKUjJKUlJKUjJKUlJKUjJKUlJKUjJKUlJKUjJKUlJKUjJKUlJKUjI6MlJKU
3t/e//////////////////////////////////////////////////v/tbK1lI6UlJKUlJKUjJKU
lJKUjJKUlJKUjJKUlJKUjJKUlJKUjJKUlJKUjJKUlJKUjJKUlJKUjJKUlJKUjJKUlJKUjJKUlJKU
jJKUlJKUjJKUlJKUjJKUlJKUjJKUlJKUjJKUlJKUjJKUjIqMra6t//v/////////////////xsPG
lJKUjI6MhIKEc3Vzc3Vzc3Vze3l7c3Vzc3V7c3Vzc3V7c3Vzc3V7c3V7c3Vzc3VznJ6ctbK159/n
//v/////////////////////////////////////////59/WjFlKnE0xpVExpVU5nFExpVU5nFEx
pVU5nFExpVU5nFExpVU5nFExpVU5nFExpVU5nFUxjFEppXVa9/f39///////9///////////////
zrqtlGlShE0xeywIjCwAlCwAjCwAlDQInDQInDAInDAIpTQInDAIlCwIhCQAjCwQnFlCrYpz1se1
//fv////////////////////////9///9///9///////////7+verZZ7nHFahEkphDQQjCQAnCwI
nDAInDAInDAIpTAInDAIpTQQnDAIlCwAjCgAhCgIhDwYlGVCpYZj1r6t//v3//////v/////////
////////////////////////////////////////AAAA////////////////////////////////
////////////////////////////////////5+vvxsPGvbq9raqtjJKUlJaclJKUlJaUlJKUlJKU
lJKUraatvbq91tPW7+vv//////////////////////////v/7+vv9+/37+vv9+/37+vv7+/37+vv
7+/37+vv7+/37+vv7+/37+vv7+/37+vv7+/37+vv7+/37+vv7+/37+vv7+/37+vv7+/37+vv7+/3
7+vv7+/37+vv7+/37+vv7+/37+vv7+/v7+vv//v/////////////////////////////////5+Pn
zsvOpaatjIaMc3Fzc3Fze317lJKUlJaUtbK1vbq91tfe////////////////////9/f31tfevba9
nJqclJKUjJKUlJKUlJKUlJaUlJKUlJaclJKUlJaUlJKUpaKlvbq9vbq9vb695+Pn7+/v7+vv////
//////////////////////////////////////////////v/9/P37+vv9+/37+vv9+/37+vv7+/3
7+vv7+/37+vv7+/37+vv7+/37+vv7+/37+vv7+/37+vv7+/v7+vv//v/////////////////////
////////////////////////////////9/P37+vv9+/37+vv7+/37+vv7+/37+vv7+/37+vv7+/3
7+vv7+/37+vv7+/37+vv7+/37+vv7+/37+vv7+/37+vv7+/37+vv7+/37+vv7+/37+vv7+/37+vv
7+/37+vv7+/37+vv9+/37+vv9/P3//////////v/////////////7+vv7+vvzs/Ovbq9ra6tlJac
jI6MlJKUlJKUlJaUlJKUlJKUlJKUlJacpaatzsfO9/P3////////////////////////////////
//////////////v/////9/v39+Pe7+PW7+Pe7+PW7+Pe7+Pe7+Pe7+PW7+Pe7+Pe7+Pe7+PW7+Pe
7+Pe7+Pe7+PW7+fe5+PW9+fn//v/////////////////////////////9/Pn59fOtZaErXValFUx
pVk5jDQYeyAAhCAAjCAIhCAAeyAAjDwYnF1Cxp6U7+Pe//////////////////v/////////////
////////////////////////////////9/Pv59POvaKMpW1alE0xhCgQeyAAhCQIhCAAhCQIeyAA
cyAAhDgYpWVKtYpz1rqt9+ve//////////////v/////////////////////////////////////
////////////////AAAA////////////////////////////////////////////////////////
//////////v/////////////9/f35+fv5+fv7+vv5+fn7+vv5+fv5+fv9/f3//////////////v/
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////v/1tfWxsPGvbq9zsvO
5+fn7+/v////////////////////////////////////////////9/P35+fn7+vv5+fv7+vv5+fn
7+vv5+fv7+vv5+fn7+vv9/P3////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
//////////////////v/////////////////////////////5+vv5+fn5+fv7+vv5+fn7+vv5+vv
7+vv5+vv//v///////////v///v///////////////////////////////////////v/9/v/9///
////////////////////////////////////////////////////////////////////////////
//v///v///////////////////////v/////////////9/Pn79/W79/WzraltZqEvZqMvZqMvZ6M
tZqE1sOt7+PW//////////////////////////////v////////////////////////3////////
//v///v/////////////9+/n59PGvaKUvZ6MvZqMvZ6MvZqMvZ6MtZaEzr6t7+fW////////////
///////////////////3////////////////////////////////////////////////AAAA////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////AAAA////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////AAAA////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////AAAA
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////AAAA
 " >
 </img>
									<h1 align="center">
										<span style="font-weight:bold; ">
											<xsl:text></xsl:text>
										</span>
									</h1>
								</td>
						     
								<td width="20%"/>
							</tr>
							<tr style="height:118px; " valign="top">
								<td width="40%" align="right" valign="bottom">
									<table id="customerPartyTable" align="left" border="0"
										height="50%">
										<tbody>
											<tr style="height:71px; ">
												<td>
												<hr/>
												<table align="center" border="0">
												<tbody>
												<tr>
												<xsl:for-each select="n1:Invoice">
												<xsl:for-each select="cac:AccountingCustomerParty">
												<xsl:for-each select="cac:Party">
												<td style="width:469px; " align="left">
												<span style="font-weight:bold; ">
												<xsl:text>SAYIN</xsl:text>
												</span>
												</td>
												</xsl:for-each>
												</xsl:for-each>
												</xsl:for-each>
												</tr>
												<tr>
												<xsl:for-each select="n1:Invoice">
												<xsl:for-each select="cac:AccountingCustomerParty">
												<xsl:for-each select="cac:Party">
												<td style="width:469px; " align="left">
												<xsl:if test="cac:PartyName">
												<xsl:value-of select="cac:PartyName/cbc:Name"/>
												<br/>
												</xsl:if>
												<xsl:for-each select="cac:Person">
												<xsl:for-each select="cbc:Title">
												<xsl:apply-templates/>
												<span>
												<xsl:text>&#160;</xsl:text>
												</span>
												</xsl:for-each>
												<xsl:for-each select="cbc:FirstName">
												<xsl:apply-templates/>
												<span>
												<xsl:text>&#160;</xsl:text>
												</span>
												</xsl:for-each>
												<xsl:for-each select="cbc:MiddleName">
												<xsl:apply-templates/>
												<span>
												<xsl:text>&#160; </xsl:text>
												</span>
												</xsl:for-each>
												<xsl:for-each select="cbc:FamilyName">
												<xsl:apply-templates/>
												<span>
												<xsl:text>&#160;</xsl:text>
												</span>
												</xsl:for-each>
												<xsl:for-each select="cbc:NameSuffix">
												<xsl:apply-templates/>
												</xsl:for-each>
												</xsl:for-each>
												</td>
												</xsl:for-each>
												</xsl:for-each>
												</xsl:for-each>
												</tr>
												<tr>
												<xsl:for-each select="n1:Invoice">
												<xsl:for-each select="cac:AccountingCustomerParty">
												<xsl:for-each select="cac:Party">
												<td style="width:469px; " align="left">
												<xsl:for-each select="cac:PostalAddress">
												<xsl:for-each select="cbc:StreetName">
												<xsl:apply-templates/>
												<span>
												<xsl:text>&#160;</xsl:text>
												</span>
												</xsl:for-each>
												<xsl:for-each select="cbc:BuildingName">
												<xsl:apply-templates/>
												</xsl:for-each>
												<xsl:for-each select="cbc:BuildingNumber">
												<span>
												<xsl:text> No:</xsl:text>
												</span>
												<xsl:apply-templates/>
												<span>
												<xsl:text>&#160;</xsl:text>
												</span>
												</xsl:for-each>
												<br/>
												<xsl:for-each select="cbc:Room">
												<span>
												<xsl:text>Kapı No:</xsl:text>
												</span>
												<xsl:apply-templates/>
												<span>
												<xsl:text>&#160;</xsl:text>
												</span>
												</xsl:for-each>
												<br/>
												<xsl:for-each select="cbc:PostalZone">
												<xsl:apply-templates/>
												<span>
												<xsl:text>&#160;</xsl:text>
												</span>
												</xsl:for-each>
												<xsl:for-each select="cbc:CitySubdivisionName">
												<xsl:apply-templates/>
												<span>
												<xsl:text>/ </xsl:text>
												</span>
												</xsl:for-each>
												<xsl:for-each select="cbc:CityName">
												<xsl:apply-templates/>
												<span>
												<xsl:text>&#160;</xsl:text>
												</span>
												</xsl:for-each>
												</xsl:for-each>
												</td>
												</xsl:for-each>
												</xsl:for-each>
												</xsl:for-each>
												</tr>
												<xsl:for-each
												select="//n1:Invoice/cac:AccountingCustomerParty/cac:Party/cbc:WebsiteURI">
												<tr align="left">
												<td>
												<xsl:text>Web Sitesi: </xsl:text>
												<xsl:value-of select="."/>
												</td>
												</tr>
												</xsl:for-each>
												<xsl:for-each
												select="//n1:Invoice/cac:AccountingCustomerParty/cac:Party/cac:Contact/cbc:ElectronicMail">
												<tr align="left">
												<td>
												<xsl:text>E-Posta: </xsl:text>
												<xsl:value-of select="."/>
												</td>
												</tr>
												</xsl:for-each>
												<xsl:for-each select="n1:Invoice">
												<xsl:for-each select="cac:AccountingCustomerParty">
												<xsl:for-each select="cac:Party">
												<xsl:for-each select="cac:Contact">
												<xsl:if test="cbc:Telephone or cbc:Telefax">
												<tr align="left">
												<td style="width:469px; " align="left">
												<xsl:for-each select="cbc:Telephone">
												<span>
												<xsl:text>Tel: </xsl:text>
												</span>
												<xsl:apply-templates/>
												</xsl:for-each>
												<xsl:for-each select="cbc:Telefax">
												<span>
												<xsl:text> Fax: </xsl:text>
												</span>
												<xsl:apply-templates/>
												</xsl:for-each>
												<span>
												<xsl:text>&#160;</xsl:text>
												</span>
												</td>
												</tr>
												</xsl:if>
												<xsl:if
												test="//n1:Invoice/cac:AccountingCustomerParty/cac:Party/cac:PartyTaxScheme/cac:TaxScheme/cbc:Name">
												<tr align="left">
												<td>
												<span>
												<xsl:text>Vergi Dairesi: </xsl:text>
												<xsl:value-of
												select="//n1:Invoice/cac:AccountingCustomerParty/cac:Party/cac:PartyTaxScheme/cac:TaxScheme/cbc:Name"
												/>
												</span>
												</td>
												</tr>
												</xsl:if>
												</xsl:for-each>
												</xsl:for-each>
												</xsl:for-each>
												</xsl:for-each>
												<xsl:for-each
												select="//n1:Invoice/cac:AccountingCustomerParty/cac:Party/cac:PartyIdentification">
												<tr align="left">
												<td>
												<xsl:value-of select="cbc:ID/@schemeID"/>
												<xsl:text>: </xsl:text>
												<xsl:value-of select="cbc:ID"/>
												</td>
												</tr>
												</xsl:for-each>
												</tbody>
												</table>
												<hr/>
												</td>
											</tr>
										</tbody>
									</table>
									<br/>
								</td>
								<td width="60%" align="center" valign="bottom" colspan="2">
									<table border="1" height="13" id="despatchTable">
										<tbody>
											<tr>
												<td style="width:105px;" align="left">
												<span style="font-weight:bold; ">
												<xsl:text>Özelleştirme No:</xsl:text>
												</span>
												</td>
												<td style="width:110px;" align="left">
												<xsl:for-each select="n1:Invoice">
												<xsl:for-each select="cbc:CustomizationID">
												<xsl:apply-templates/>
												</xsl:for-each>
												</xsl:for-each>
												</td>
											</tr>
											<tr style="height:13px; ">
												<td align="left">
												<span style="font-weight:bold; ">
												<xsl:text>Senaryo:</xsl:text>
												</span>
												</td>
												<td align="left">
												<xsl:for-each select="n1:Invoice">
												<xsl:for-each select="cbc:ProfileID">
												<xsl:apply-templates/>
												</xsl:for-each>
												</xsl:for-each>
												</td>
											</tr>
											<tr style="height:13px; ">
												<td align="left">
												<span style="font-weight:bold; ">
												<xsl:text>Fatura Tipi:</xsl:text>
												</span>
												</td>
												<td align="left">
												<xsl:for-each select="n1:Invoice">
												<xsl:for-each select="cbc:InvoiceTypeCode">
												<xsl:apply-templates/>
												</xsl:for-each>
												</xsl:for-each>
												</td>
											</tr>
											<tr style="height:13px; ">
												<td align="left">
												<span style="font-weight:bold; ">
												<xsl:text>Fatura No:</xsl:text>
												</span>
												</td>
												<td align="left">
												<xsl:for-each select="n1:Invoice">
												<xsl:for-each select="cbc:ID">
												<xsl:apply-templates/>
												</xsl:for-each>
												</xsl:for-each>
												</td>
											</tr>
											<tr style="height:13px; ">
												<td align="left">
												<span style="font-weight:bold; ">
												<xsl:text>Fatura Tarihi:</xsl:text>
												</span>
												</td>
												<td align="left">
												<xsl:for-each select="n1:Invoice">
												<xsl:for-each select="cbc:IssueDate">
												<xsl:value-of select="substring(.,9,2)"
												/>-<xsl:value-of select="substring(.,6,2)"
												/>-<xsl:value-of select="substring(.,1,4)"/>
												</xsl:for-each>
												</xsl:for-each>
												</td>
											</tr>
											<xsl:for-each
												select="n1:Invoice/cac:DespatchDocumentReference">
												<tr style="height:13px; ">
												<td align="left">
												<span style="font-weight:bold; ">
												<xsl:text>İrsaliye No:</xsl:text>
												</span>
												<span>
												<xsl:text>&#160;</xsl:text>
												</span>
												</td>
												<td align="left">
												<xsl:value-of select="cbc:ID"/>
												</td>
												</tr>
												<tr style="height:13px; ">
												<td align="left">
												<span style="font-weight:bold; ">
												<xsl:text>İrsaliye Tarihi:</xsl:text>
												</span>
												</td>
												<td align="left">
												<xsl:for-each select="cbc:IssueDate">
												<xsl:value-of select="substring(.,9,2)"
												/>-<xsl:value-of select="substring(.,6,2)"
												/>-<xsl:value-of select="substring(.,1,4)"/>
												</xsl:for-each>
												</td>
												</tr>
											</xsl:for-each>
											<xsl:if test="//n1:Invoice/cac:OrderReference">
												<tr style="height:13px">
												<td align="left">
												<span style="font-weight:bold; ">
												<xsl:text>Sipariş No:</xsl:text>
												</span>
												</td>
												<td align="left">
												<xsl:for-each
												select="n1:Invoice/cac:OrderReference">
												<xsl:for-each select="cbc:ID">
												<xsl:apply-templates/>
												</xsl:for-each>
												</xsl:for-each>
												</td>
												</tr>
											</xsl:if>
											<xsl:if
												test="//n1:Invoice/cac:OrderReference/cbc:IssueDate">
												<tr style="height:13px">
												<td align="left">
												<span style="font-weight:bold; ">
												<xsl:text>Sipariş Tarihi:</xsl:text>
												</span>
												</td>
												<td align="left">
												<xsl:for-each
												select="n1:Invoice/cac:OrderReference">
												<xsl:for-each select="cbc:IssueDate">
												<xsl:value-of select="substring(.,9,2)"
												/>-<xsl:value-of select="substring(.,6,2)"
												/>-<xsl:value-of select="substring(.,1,4)"/>
												</xsl:for-each>
												</xsl:for-each>
												</td>
												</tr>
											</xsl:if>
										</tbody>
									</table>
								</td>
							</tr>
							<tr align="left">
								<table id="ettnTable">
									<tr style="height:13px;">
										<td align="left" valign="top">
											<span style="font-weight:bold; ">
												<xsl:text>ETTN:</xsl:text>
											</span>
										</td>
										<td align="left" width="240px">
											<xsl:for-each select="n1:Invoice">
												<xsl:for-each select="cbc:UUID">
												<xsl:apply-templates/>
												</xsl:for-each>
											</xsl:for-each>
										</td>
									</tr>
								</table>
							</tr>
						</tbody>
					</table>
					
					<div id="lineTableAligner">
						<span>
							<xsl:text>&#160;</xsl:text>
						</span>
					</div>
					
					<table border="1" id="lineTable" width="850">
						<tbody>
						
							<tr id="lineTableTr">
								<td id="lineTableTd" style="width:3%">
									<span style="font-weight:bold; " align="center">
										<xsl:text>Sıra No</xsl:text>
									</span>
								</td>
								<td id="lineTableTd" style="width:23%" align="center">
									<span style="font-weight:bold; ">
										<xsl:text>Mal Hizmet</xsl:text>
									</span>
								</td>
								<td id="lineTableTd" style="width:7.4%" align="center">
									<span style="font-weight:bold;">
										<xsl:text>Miktar</xsl:text>
									</span>
								</td>
								<td id="lineTableTd" style="width:9%" align="center">
									<span style="font-weight:bold; ">
										<xsl:text>Birim Fiyat</xsl:text>
									</span>
								</td>
								
							 
								
								<td id="lineTableTd" style="width:7%" align="center">
									<span style="font-weight:bold; ">
										<xsl:text>İskonto Oranı</xsl:text>
									</span>
								</td>
								<td id="lineTableTd" style="width:9%" align="center">
									<span style="font-weight:bold; ">
										<xsl:text>İskonto Tutarı</xsl:text>
									</span>
								</td>
								<td id="lineTableTd" style="width:7%" align="center">
									<span style="font-weight:bold; ">
										<xsl:text>KDV Oranı</xsl:text>
									</span>
								</td>
								<td id="lineTableTd" style="width:10%" align="center">
									<span style="font-weight:bold; ">
										<xsl:text>KDV Tutarı</xsl:text>
									</span>
								</td>
								<td id="lineTableTd" style="width:15%; " align="center">
									<span style="font-weight:bold; ">
										<xsl:text>Diğer Vergiler</xsl:text>
									</span>
								</td>
								
								<td id="lineTableTd" style="width:13.6%" align="center">
									<span style="font-weight:bold; ">
										<xsl:text>Mal Hizmet Tutarı</xsl:text>
									</span>
								</td>
														
								
							</tr>
							<!-- &gt;= 20 -->
							<xsl:if test="count(//n1:Invoice/cac:InvoiceLine) "> 
								<xsl:for-each select="//n1:Invoice/cac:InvoiceLine">
									<xsl:apply-templates select="."/>
								</xsl:for-each>
							</xsl:if>
						 <!--
							<xsl:if test="count(//n1:Invoice/cac:InvoiceLine) &lt; 20">
								<xsl:choose>
									<xsl:when test="//n1:Invoice/cac:InvoiceLine[1]">
										<xsl:apply-templates
											select="//n1:Invoice/cac:InvoiceLine[1]"/>
									</xsl:when>
									<xsl:otherwise>
										<xsl:apply-templates select="//n1:Invoice"/>
									</xsl:otherwise>
								</xsl:choose>
								<xsl:choose>
									<xsl:when test="//n1:Invoice/cac:InvoiceLine[2]">
										<xsl:apply-templates
											select="//n1:Invoice/cac:InvoiceLine[2]"/>
									</xsl:when>
									<xsl:otherwise>
										<xsl:apply-templates select="//n1:Invoice"/>
									</xsl:otherwise>
								</xsl:choose>
								<xsl:choose>
									<xsl:when test="//n1:Invoice/cac:InvoiceLine[3]">
										<xsl:apply-templates
											select="//n1:Invoice/cac:InvoiceLine[3]"/>
									</xsl:when>
									<xsl:otherwise>
										<xsl:apply-templates select="//n1:Invoice"/>
									</xsl:otherwise>
								</xsl:choose>
								<xsl:choose>
									<xsl:when test="//n1:Invoice/cac:InvoiceLine[4]">
										<xsl:apply-templates
											select="//n1:Invoice/cac:InvoiceLine[4]"/>
									</xsl:when>
									<xsl:otherwise>
										<xsl:apply-templates select="//n1:Invoice"/>
									</xsl:otherwise>
								</xsl:choose>
								<xsl:choose>
									<xsl:when test="//n1:Invoice/cac:InvoiceLine[5]">
										<xsl:apply-templates
											select="//n1:Invoice/cac:InvoiceLine[5]"/>
									</xsl:when>
									<xsl:otherwise>
										<xsl:apply-templates select="//n1:Invoice"/>
									</xsl:otherwise>
								</xsl:choose>
								<xsl:choose>
									<xsl:when test="//n1:Invoice/cac:InvoiceLine[6]">
										<xsl:apply-templates
											select="//n1:Invoice/cac:InvoiceLine[6]"/>
									</xsl:when>
									<xsl:otherwise>
										<xsl:apply-templates select="//n1:Invoice"/>
									</xsl:otherwise>
								</xsl:choose>
								<xsl:choose>
									<xsl:when test="//n1:Invoice/cac:InvoiceLine[7]">
										<xsl:apply-templates
											select="//n1:Invoice/cac:InvoiceLine[7]"/>
									</xsl:when>
									<xsl:otherwise>
										<xsl:apply-templates select="//n1:Invoice"/>
									</xsl:otherwise>
								</xsl:choose>
								<xsl:choose>
									<xsl:when test="//n1:Invoice/cac:InvoiceLine[8]">
										<xsl:apply-templates
											select="//n1:Invoice/cac:InvoiceLine[8]"/>
									</xsl:when>
									<xsl:otherwise>
										<xsl:apply-templates select="//n1:Invoice"/>
									</xsl:otherwise>
								</xsl:choose>
								<xsl:choose>
									<xsl:when test="//n1:Invoice/cac:InvoiceLine[9]">
										<xsl:apply-templates
											select="//n1:Invoice/cac:InvoiceLine[9]"/>
									</xsl:when>
									<xsl:otherwise>
										<xsl:apply-templates select="//n1:Invoice"/>
									</xsl:otherwise>
								</xsl:choose>
								<xsl:choose>
									<xsl:when test="//n1:Invoice/cac:InvoiceLine[10]">
										<xsl:apply-templates
											select="//n1:Invoice/cac:InvoiceLine[10]"/>
									</xsl:when>
									<xsl:otherwise>
										<xsl:apply-templates select="//n1:Invoice"/>
									</xsl:otherwise>
								</xsl:choose>
								<xsl:choose>
									<xsl:when test="//n1:Invoice/cac:InvoiceLine[11]">
										<xsl:apply-templates
											select="//n1:Invoice/cac:InvoiceLine[11]"/>
									</xsl:when>
									<xsl:otherwise>
										<xsl:apply-templates select="//n1:Invoice"/>
									</xsl:otherwise>
								</xsl:choose>
								<xsl:choose>
									<xsl:when test="//n1:Invoice/cac:InvoiceLine[12]">
										<xsl:apply-templates
											select="//n1:Invoice/cac:InvoiceLine[12]"/>
									</xsl:when>
									<xsl:otherwise>
										<xsl:apply-templates select="//n1:Invoice"/>
									</xsl:otherwise>
								</xsl:choose>
								<xsl:choose>
									<xsl:when test="//n1:Invoice/cac:InvoiceLine[13]">
										<xsl:apply-templates
											select="//n1:Invoice/cac:InvoiceLine[13]"/>
									</xsl:when>
									<xsl:otherwise>
										<xsl:apply-templates select="//n1:Invoice"/>
									</xsl:otherwise>
								</xsl:choose>
								<xsl:choose>
									<xsl:when test="//n1:Invoice/cac:InvoiceLine[14]">
										<xsl:apply-templates
											select="//n1:Invoice/cac:InvoiceLine[14]"/>
									</xsl:when>
									<xsl:otherwise>
										<xsl:apply-templates select="//n1:Invoice"/>
									</xsl:otherwise>
								</xsl:choose>
								<xsl:choose>
									<xsl:when test="//n1:Invoice/cac:InvoiceLine[15]">
										<xsl:apply-templates
											select="//n1:Invoice/cac:InvoiceLine[15]"/>
									</xsl:when>
									<xsl:otherwise>
										<xsl:apply-templates select="//n1:Invoice"/>
									</xsl:otherwise>
								</xsl:choose>
								<xsl:choose>
									<xsl:when test="//n1:Invoice/cac:InvoiceLine[16]">
										<xsl:apply-templates
											select="//n1:Invoice/cac:InvoiceLine[16]"/>
									</xsl:when>
									<xsl:otherwise>
										<xsl:apply-templates select="//n1:Invoice"/>
									</xsl:otherwise>
								</xsl:choose>
								<xsl:choose>
									<xsl:when test="//n1:Invoice/cac:InvoiceLine[17]">
										<xsl:apply-templates
											select="//n1:Invoice/cac:InvoiceLine[17]"/>
									</xsl:when>
									<xsl:otherwise>
										<xsl:apply-templates select="//n1:Invoice"/>
									</xsl:otherwise>
								</xsl:choose>
								<xsl:choose>
									<xsl:when test="//n1:Invoice/cac:InvoiceLine[18]">
										<xsl:apply-templates
											select="//n1:Invoice/cac:InvoiceLine[18]"/>
									</xsl:when>
									<xsl:otherwise>
										<xsl:apply-templates select="//n1:Invoice"/>
									</xsl:otherwise>
								</xsl:choose>
								<xsl:choose>
									<xsl:when test="//n1:Invoice/cac:InvoiceLine[19]">
										<xsl:apply-templates
											select="//n1:Invoice/cac:InvoiceLine[19]"/>
									</xsl:when>
									<xsl:otherwise>
										<xsl:apply-templates select="//n1:Invoice"/>
									</xsl:otherwise>
								</xsl:choose>
								<xsl:choose>
									<xsl:when test="//n1:Invoice/cac:InvoiceLine[20]">
										<xsl:apply-templates
											select="//n1:Invoice/cac:InvoiceLine[20]"/>
									</xsl:when>
									<xsl:otherwise>
										<xsl:apply-templates select="//n1:Invoice"/>
									</xsl:otherwise>
								</xsl:choose>
							</xsl:if>
						   -->
						</tbody>
					</table>
				</xsl:for-each>
				
				<table id="budgetContainerTable" width="850">
					<tr id="budgetContainerTr" align="right">
						<td id="budgetContainerDummyTd"/>
						<td id="lineTableBudgetTd" align="right" width="200px">
							<span style="font-weight:bold; ">
								<xsl:text>Mal Hizmet Toplam Tutarı</xsl:text>
							</span>
						</td>
						<td id="lineTableBudgetTd" style="width:81px; " align="right">
							<span>
								<xsl:value-of
									select="format-number(//n1:Invoice/cac:LegalMonetaryTotal/cbc:LineExtensionAmount, '###.##0,00', 'european')"/>
								<xsl:if
									test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:LineExtensionAmount/@currencyID">
									<xsl:text> </xsl:text>
									<xsl:if
										test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:LineExtensionAmount/@currencyID = 'TRL'">
										<xsl:text>TL</xsl:text>
									</xsl:if>
									<xsl:if
										test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:LineExtensionAmount/@currencyID != 'TRL'">
										<xsl:value-of
											select="//n1:Invoice/cac:LegalMonetaryTotal/cbc:LineExtensionAmount/@currencyID"
										/>
									</xsl:if>
								</xsl:if>
							</span>
						</td>
					</tr>
					<tr id="budgetContainerTr" align="right">
						<td id="budgetContainerDummyTd"/>
						<td id="lineTableBudgetTd" align="right" width="200px">
							<span style="font-weight:bold; ">
								<xsl:text>Toplam İskonto</xsl:text>
							</span>
						</td>
						<td id="lineTableBudgetTd" style="width:81px; " align="right">
							<span>
								<xsl:value-of
									select="format-number(//n1:Invoice/cac:LegalMonetaryTotal/cbc:AllowanceTotalAmount, '###.##0,00', 'european')"/>
								<xsl:if
									test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:AllowanceTotalAmount/@currencyID">
									<xsl:text> </xsl:text>
									<xsl:if
										test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:AllowanceTotalAmount/@currencyID = 'TRL'">
										<xsl:text>TL</xsl:text>
									</xsl:if>
									<xsl:if
										test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:AllowanceTotalAmount/@currencyID != 'TRL'">
										<xsl:value-of
											select="//n1:Invoice/cac:LegalMonetaryTotal/cbc:AllowanceTotalAmount/@currencyID"
										/>
									</xsl:if>
								</xsl:if>
							</span>
						</td>
					</tr>
					<xsl:for-each select="n1:Invoice/cac:TaxTotal/cac:TaxSubtotal">
						<tr id="budgetContainerTr" align="right">
							<td id="budgetContainerDummyTd"/>
							<td id="lineTableBudgetTd" width="211px" align="right">
								<span style="font-weight:bold; ">
									<xsl:text>Hesaplanan </xsl:text>
									<xsl:value-of select="cac:TaxCategory/cac:TaxScheme/cbc:Name"/>
									<xsl:text>(%</xsl:text>
									<xsl:value-of select="cbc:Percent"/>
									<xsl:text>)</xsl:text>
								</span>
							</td>
							<td id="lineTableBudgetTd" style="width:82px; " align="right">
								<xsl:for-each select="cac:TaxCategory/cac:TaxScheme">
									<xsl:text> </xsl:text>
									<xsl:value-of
										select="format-number(../../cbc:TaxAmount, '###.##0,00', 'european')"/>
									<xsl:if test="../../cbc:TaxAmount/@currencyID">
										<xsl:text> </xsl:text>
										<xsl:if test="../../cbc:TaxAmount/@currencyID = 'TRL'">
											<xsl:text>TL</xsl:text>
										</xsl:if>
										<xsl:if test="../../cbc:TaxAmount/@currencyID != 'TRL'">
											<xsl:value-of select="../../cbc:TaxAmount/@currencyID"/>
										</xsl:if>
									</xsl:if>
								</xsl:for-each>
							</td>
						</tr>
					</xsl:for-each>
					<tr id="budgetContainerTr" align="right">
						<td id="budgetContainerDummyTd"/>
						<td id="lineTableBudgetTd" width="200px" align="right">
							<span style="font-weight:bold; ">
								<xsl:text>Vergiler Dahil Toplam Tutar</xsl:text>
							</span>
						</td>
						<td id="lineTableBudgetTd" style="width:82px; " align="right">
							<xsl:for-each select="n1:Invoice">
								<xsl:for-each select="cac:LegalMonetaryTotal">
									<xsl:for-each select="cbc:TaxInclusiveAmount">
										<xsl:value-of
											select="format-number(., '###.##0,00', 'european')"/>
										<xsl:if
											test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:TaxInclusiveAmount/@currencyID">
											<xsl:text> </xsl:text>
											<xsl:if
												test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:TaxInclusiveAmount/@currencyID = 'TRL'">
												<xsl:text>TL</xsl:text>
											</xsl:if>
											<xsl:if
												test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:TaxInclusiveAmount/@currencyID != 'TRL'">
												<xsl:value-of
												select="//n1:Invoice/cac:LegalMonetaryTotal/cbc:TaxInclusiveAmount/@currencyID"
												/>
											</xsl:if>
										</xsl:if>
									</xsl:for-each>
								</xsl:for-each>
							</xsl:for-each>
						</td>
					</tr>
					<tr id="budgetContainerTr" align="right">
						<td id="budgetContainerDummyTd"/>
						<td id="lineTableBudgetTd" width="200px" align="right">
							<span style="font-weight:bold; ">
								<xsl:text>Ödenecek Tutar</xsl:text>
							</span>
						</td>
						<td id="lineTableBudgetTd" style="width:82px; " align="right">
							<xsl:for-each select="n1:Invoice">
								<xsl:for-each select="cac:LegalMonetaryTotal">
									<xsl:for-each select="cbc:PayableAmount">
										<xsl:value-of
											select="format-number(., '###.##0,00', 'european')"/>
										<xsl:if
											test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:PayableAmount/@currencyID">
											<xsl:text> </xsl:text>
											<xsl:if
												test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:PayableAmount/@currencyID = 'TRL'">
												<xsl:text>TL</xsl:text>
											</xsl:if>
											<xsl:if
												test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:PayableAmount/@currencyID != 'TRL'">
												<xsl:value-of
												select="//n1:Invoice/cac:LegalMonetaryTotal/cbc:PayableAmount/@currencyID"
												/>
											</xsl:if>
										</xsl:if>
									</xsl:for-each>
								</xsl:for-each>
							</xsl:for-each>
						</td>
					</tr>
				</table>
				<br/>
				<table id="notesTable" width="850" align="left" height="150">
					<tbody>
						<tr align="left">
							<td id="notesTableTd">
								
								<!--
								<xsl:if test="//n1:Invoice/cbc:Note">
									<b>&#160;&#160;&#160;&#160;&#160; Not: </b>
									<xsl:value-of select="//n1:Invoice/cbc:Note"/>
									<br/>
								</xsl:if>
								-->
								
							 	<xsl:if test="//n1:Invoice/cbc:Note">							      
									<table>
										<xsl:for-each select="//n1:Invoice/cbc:Note">
											<tr>
												<td>
													<xsl:value-of select="."/>
												</td>
											</tr>
										</xsl:for-each>
									</table>
									<br/>
								</xsl:if>
								
								<xsl:if test="//n1:Invoice/cac:PaymentMeans/cbc:InstructionNote">
									<b>&#160;&#160;&#160;&#160;&#160; Ödeme
										Notu: </b>
									<xsl:value-of
										select="//n1:Invoice/cac:PaymentMeans/cbc:InstructionNote"/>
									<br/>
								</xsl:if>
								<xsl:if
									test="//n1:Invoice/cac:PaymentMeans/cac:PayeeFinancialAccount/cbc:PaymentNote">
									<b>&#160;&#160;&#160;&#160;&#160; Hesap
										Açıklaması: </b>
									<xsl:value-of
										select="//n1:Invoice/cac:PaymentMeans/cac:PayeeFinancialAccount/cbc:PaymentNote"/>
									<br/>
								</xsl:if>
								<xsl:if test="//n1:Invoice/cac:PaymentTerms/cbc:Note">
									<b>&#160;&#160;&#160;&#160;&#160; Ödeme
										Koşulu: </b>
									<xsl:value-of select="//n1:Invoice/cac:PaymentTerms/cbc:Note"/>
									<br/>
								</xsl:if>
								<br/>
								<br/>

								<xsl:text>Groupm Medya Hizm Ltd Şti</xsl:text>
								<br/>

								<xsl:text>Banka Adı	Şube Adı	Şube Kodu	Hesap No	IBAN	Döviz Cinsi</xsl:text>
								<br/>

								<xsl:text>HSBC Bankası	Küresel Bankacılık Merkezi	123	1028485-282-00	TR640012300744102848528200	TL</xsl:text>
								<br/>
								<xsl:text>HSBC Bankası	Küresel Bankacılık Merkezi	123	1028485-773-01	TR150012300123102848577301	USD</xsl:text>
								<br/>
								<xsl:text>HSBC Bankası	Küresel Bankacılık Merkezi	123	1028485-773-99	TR850012300123102848577399	EURO</xsl:text>
								<br/>
								<xsl:text>HSBC Bankası	Küresel Bankacılık Merkezi	123	1028485-773-05	TR040012300123102848577305	GBP</xsl:text>
								<br/>
								
							</td>
						</tr>
					</tbody>
				</table>
			</body>
		
		</html>
	</xsl:template>
	
	<xsl:template match="dateFormatter">
		<xsl:value-of select="substring(.,9,2)"/>-<xsl:value-of select="substring(.,6,2)"
			/>-<xsl:value-of select="substring(.,1,4)"/>
	</xsl:template>
	
	<xsl:template match="//n1:Invoice/cac:InvoiceLine">
		
		<tr id="lineTableTr">
		
			<td id="lineTableTd">
				<span>
					<xsl:text>&#160;</xsl:text>
					<xsl:value-of select="./cbc:ID"/>
				</span>
			</td>
			
			<td id="lineTableTd">
				<span>
					<xsl:text>&#160;</xsl:text>
					<xsl:value-of select="./cac:Item/cbc:Name"/>
					<!--	<xsl:text>&#160;</xsl:text>
					<xsl:value-of select="./cac:Item/cbc:BrandName"/>
					<xsl:text>&#160;</xsl:text>
					<xsl:value-of select="./cac:Item/cbc:ModelName"/>
					<xsl:text>&#160;</xsl:text>
					<xsl:value-of select="./cac:Item/cbc:Description"/>-->
				</span>
			</td>
			
			<td id="lineTableTd" align="right">
				<span>
					<xsl:text>&#160;</xsl:text>
					<xsl:value-of
						select="format-number(./cbc:InvoicedQuantity, '###.###,##', 'european')"/>
					<xsl:if test="./cbc:InvoicedQuantity/@unitCode">
						<xsl:for-each select="./cbc:InvoicedQuantity">
							<xsl:text> </xsl:text>
							<xsl:choose>
								<xsl:when test="@unitCode  = '26'">
									<span>
										<xsl:text>Ton</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'BX'">
									<span>
										<xsl:text>Kutu</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'LTR'">
									<span>
										<xsl:text>LT</xsl:text>
									</span>
								</xsl:when>

								<xsl:when test="@unitCode  = 'NIU'">
									<span>
										<xsl:text>Adet</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'KGM'">
									<span>
										<xsl:text>KG</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'KJO'">
									<span>
										<xsl:text>kJ</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'GRM'">
									<span>
										<xsl:text>G</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'MGM'">
									<span>
										<xsl:text>MG</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'NT'">
									<span>
										<xsl:text>Net Ton</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'GT'">
									<span>
										<xsl:text>GT</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'MTR'">
									<span>
										<xsl:text>M</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'MMT'">
									<span>
										<xsl:text>MM</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'KTM'">
									<span>
										<xsl:text>KM</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'MLT'">
									<span>
										<xsl:text>ML</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'MMQ'">
									<span>
										<xsl:text>MM3</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'CLT'">
									<span>
										<xsl:text>CL</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'CMK'">
									<span>
										<xsl:text>CM2</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'CMQ'">
									<span>
										<xsl:text>CM3</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'CMT'">
									<span>
										<xsl:text>CM</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'MTK'">
									<span>
										<xsl:text>M2</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'MTQ'">
									<span>
										<xsl:text>M3</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'DAY'">
									<span>
										<xsl:text> Gün</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'MON'">
									<span>
										<xsl:text> Ay</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'PA'">
									<span>
										<xsl:text> Paket</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'KWH'">
									<span>
										<xsl:text> KWH</xsl:text>
									</span>
								</xsl:when>
							</xsl:choose>
						</xsl:for-each>
					</xsl:if>
				</span>
			</td>
		
     		<td id="lineTableTd" align="right">
				<span>
					<xsl:text>&#160;</xsl:text>
					<xsl:value-of
						select="format-number(./cac:Price/cbc:PriceAmount, '###.##0,0000', 'european')"/>
					<xsl:if test="./cac:Price/cbc:PriceAmount/@currencyID">
						<xsl:text> </xsl:text>
						<xsl:if
							test="./cac:Price/cbc:PriceAmount/@currencyID = &quot;TRL&quot; ">
							<xsl:text>TL</xsl:text>
						</xsl:if>
						<xsl:if
							test="./cac:Price/cbc:PriceAmount/@currencyID != &quot;TRL&quot;">
							<xsl:value-of select="./cac:Price/cbc:PriceAmount/@currencyID"/>
						</xsl:if>
					</xsl:if>
				</span>
			</td>
			
	 
			
			<td id="lineTableTd" align="right">
				<span>
					<xsl:text>&#160;</xsl:text>
					<xsl:if test="./cac:AllowanceCharge/cbc:MultiplierFactorNumeric">
						<xsl:text> %</xsl:text>
						<xsl:value-of
							select="format-number(./cac:AllowanceCharge/cbc:MultiplierFactorNumeric * 100, '###.##0,00', 'european')"
						/>
					</xsl:if>
				</span>
			</td>
			
			<td id="lineTableTd" align="right">
				<span>
					<xsl:text>&#160;</xsl:text>
					<xsl:if test="./cac:AllowanceCharge">
						<!--<xsl:if test="./cac:AllowanceCharge/cbc:ChargeIndicator = true() ">+
										</xsl:if>
						<xsl:if test="./cac:AllowanceCharge/cbc:ChargeIndicator = false() ">-
										</xsl:if>-->
						<xsl:value-of
							select="format-number(./cac:AllowanceCharge/cbc:Amount, '###.##0,00', 'european')"
						/>
					</xsl:if>
					<xsl:if test="./cac:AllowanceCharge/cbc:Amount/@currencyID">
						<xsl:text> </xsl:text>
						<xsl:if test="./cac:AllowanceCharge/cbc:Amount/@currencyID = 'TRL'">
							<xsl:text>TL</xsl:text>
						</xsl:if>
						<xsl:if test="./cac:AllowanceCharge/cbc:Amount/@currencyID != 'TRL'">
							<xsl:value-of select="./cac:AllowanceCharge/cbc:Amount/@currencyID"/>
						</xsl:if>
					</xsl:if>
				</span>
			</td>
			<td id="lineTableTd" align="right">
				<span>
					<xsl:text>&#160;</xsl:text>
					<xsl:for-each
						select="./cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme">
						<xsl:if test="cbc:TaxTypeCode='0015' ">
							<xsl:text> </xsl:text>
							<xsl:if test="../../cbc:Percent">
								<xsl:text> %</xsl:text>
								<xsl:value-of
									select="format-number(../../cbc:Percent, '###.##0,00', 'european')"
								/>
							</xsl:if>
						</xsl:if>
					</xsl:for-each>
				</span>
			</td>
			<td id="lineTableTd" align="right">
				<span>
					<xsl:text>&#160;</xsl:text>
					<xsl:for-each
						select="./cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme">
						<xsl:if test="cbc:TaxTypeCode='0015' ">
							<xsl:text> </xsl:text>
							<xsl:value-of
								select="format-number(../../cbc:TaxAmount, '###.##0,00', 'european')"/>
							<xsl:if test="../../cbc:TaxAmount/@currencyID">
								<xsl:text> </xsl:text>
								<xsl:if test="../../cbc:TaxAmount/@currencyID = 'TRL'">
									<xsl:text>TL</xsl:text>
								</xsl:if>
								<xsl:if test="../../cbc:TaxAmount/@currencyID != 'TRL'">
									<xsl:value-of select="../../cbc:TaxAmount/@currencyID"/>
								</xsl:if>
							</xsl:if>
						</xsl:if>
					</xsl:for-each>
				</span>
			</td>
			<td id="lineTableTd" style="font-size: xx-small" align="right">
				<span>
					<xsl:text>&#160;</xsl:text>
					<xsl:for-each
						select="./cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme">
						<xsl:if test="cbc:TaxTypeCode!='0015' ">
							<xsl:text> </xsl:text>
							<xsl:value-of select="cbc:Name"/>
								<xsl:if test="../../cbc:Percent">
									<xsl:text> (%</xsl:text>
									<xsl:value-of
										select="format-number(../../cbc:Percent, '###.##0,00', 'european')"
									/>
									<xsl:text>)=</xsl:text>
								</xsl:if>
							<xsl:value-of
								select="format-number(../../cbc:TaxAmount, '###.##0,00', 'european')"/>
							<xsl:if test="../../cbc:TaxAmount/@currencyID">
								<xsl:text> </xsl:text>
								<xsl:if test="../../cbc:TaxAmount/@currencyID = 'TRL'">
									<xsl:text>TL</xsl:text>
								</xsl:if>
								<xsl:if test="../../cbc:TaxAmount/@currencyID != 'TRL'">
									<xsl:value-of select="../../cbc:TaxAmount/@currencyID"/>
								</xsl:if>
							</xsl:if>
						</xsl:if>
					</xsl:for-each>
				</span>
			</td>
			
			<td id="lineTableTd" align="right">
				<span>
					<xsl:text>&#160;</xsl:text>
					<xsl:value-of
						select="format-number(./cbc:LineExtensionAmount, '###.##0,00', 'european')"/>
					<xsl:if test="./cbc:LineExtensionAmount/@currencyID">
						<xsl:text> </xsl:text>
						<xsl:if test="./cbc:LineExtensionAmount/@currencyID = 'TRL' ">
							<xsl:text>TL</xsl:text>
						</xsl:if>
						<xsl:if test="./cbc:LineExtensionAmount/@currencyID != 'TRL' ">
							<xsl:value-of select="./cbc:LineExtensionAmount/@currencyID"/>
						</xsl:if>
					</xsl:if>
				</span>
			</td>
			
		
			
		</tr>
	
	</xsl:template>
	
	<xsl:template match="//n1:Invoice">
		<tr id="lineTableTr">
			<td id="lineTableTd">
				<span>
					<xsl:text>&#160;</xsl:text>
				</span>
			</td>
			<td id="lineTableTd">
				<span>
					<xsl:text>&#160;</xsl:text>
				</span>
			</td>
			<td id="lineTableTd" align="right">
				<span>
					<xsl:text>&#160;</xsl:text>
				</span>
			</td>
			<td id="lineTableTd" align="right">
				<span>
					<xsl:text>&#160;</xsl:text>
				</span>
			</td>
			<td id="lineTableTd" align="right">
				<span>
					<xsl:text>&#160;</xsl:text>
				</span>
			</td>
			<td id="lineTableTd" align="right">
				<span>
					<xsl:text>&#160;</xsl:text>
				</span>
			</td>
			<td id="lineTableTd" align="right">
				<span>
					<xsl:text>&#160;</xsl:text>
				</span>
			</td>
			<td id="lineTableTd" align="right">
				<span>
					<xsl:text>&#160;</xsl:text>
				</span>
			</td>
			<td id="lineTableTd" align="right">
				<span>
					<xsl:text>&#160;</xsl:text>
				</span>
			</td>
			<td id="lineTableTd" align="right">
				<span>
					<xsl:text>&#160;</xsl:text>
				</span>
			</td>
		 
		</tr>
	</xsl:template>	
</xsl:stylesheet>
