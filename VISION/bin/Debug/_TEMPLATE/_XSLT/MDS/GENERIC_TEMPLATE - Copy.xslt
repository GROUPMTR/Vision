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
	<xsl:character-map name="a"> 
		<xsl:output-character character="&#133;" string=""/> 
		<xsl:output-character character="&#158;" string=""/> 
	</xsl:character-map> 
	<xsl:decimal-format name="european" decimal-separator="," grouping-separator="." NaN=""/>
	<xsl:output version="4.0" method="html" indent="no" encoding="UTF-8"
		doctype-public="-//W3C//DTD HTML 4.01 Transitional//EN"
		doctype-system="http://www.w3.org/TR/html4/loose.dtd" use-character-maps="a"/>
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
			<body
				style="margin-left=0.6in; margin-right=0.6in; margin-top=0.79in; margin-bottom=0.79in">
				<xsl:for-each select="$XML">
					<table style="border-color:blue; " border="0" cellspacing="0px" width="800"
						cellpadding="0px">
						<tbody>
							<tr valign="top">
								<td width="40%">
									<br/>
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
								<td width="50%" align="right" valign="middle">
									<br/>
									<br/>
									<img  align="middle" alt="E-Fatura Logo"
										src="data:image/png;base64,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"></img>
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
					<table border="1" id="lineTable" width="800">
						<tbody>
							<tr id="lineTableTr">
								<td id="lineTableTd" style="width:3%">
									<span style="font-weight:bold; " align="center">
										<xsl:text>Sıra No</xsl:text>
									</span>
								</td>
								<td id="lineTableTd" style="width:20%" align="center">
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
								<td id="lineTableTd" style="width:17%; " align="center">
									<span style="font-weight:bold; ">
										<xsl:text>Diğer Vergiler</xsl:text>
									</span>
								</td>
								<td id="lineTableTd" style="width:10.6%" align="center">
									<span style="font-weight:bold; ">
										<xsl:text>Mal Hizmet Tutarı</xsl:text>
									</span>
								</td>
							</tr>
							<xsl:if test="count(//n1:Invoice/cac:InvoiceLine) &gt;= 20">
								<xsl:for-each select="//n1:Invoice/cac:InvoiceLine">
									<xsl:apply-templates select="."/>
								</xsl:for-each>
							</xsl:if>
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
						</tbody>
					</table>
				</xsl:for-each>
				<table id="budgetContainerTable" width="800px">
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
										test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:LineExtensionAmount/@currencyID = 'TRL' or //n1:Invoice/cac:LegalMonetaryTotal/cbc:LineExtensionAmount/@currencyID = 'TRY'">
										<xsl:text>TL</xsl:text>
									</xsl:if>
									<xsl:if
										test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:LineExtensionAmount/@currencyID != 'TRL' and //n1:Invoice/cac:LegalMonetaryTotal/cbc:LineExtensionAmount/@currencyID != 'TRY'">
										<xsl:value-of
											select="//n1:Invoice/cac:LegalMonetaryTotal/cbc:LineExtensionAmount/@currencyID"
										/>
									</xsl:if>
								</xsl:if>
							</span>
						</td>
					</tr>
					<xsl:for-each select="n1:Invoice/cac:TaxTotal/cac:TaxSubtotal">
						<xsl:if test="cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode = '4171'">
							<tr id="budgetContainerTr" align="right">
								<td id="budgetContainerDummyTd"/>
								<td id="lineTableBudgetTd" align="right" width="200px">
									<span style="font-weight:bold; ">
										<xsl:text>Teslim Bedeli</xsl:text>
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
												test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:LineExtensionAmount/@currencyID = 'TRL' or //n1:Invoice/cac:LegalMonetaryTotal/cbc:LineExtensionAmount/@currencyID = 'TRY'">
												<xsl:text>TL</xsl:text>
											</xsl:if>
											<xsl:if
												test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:LineExtensionAmount/@currencyID != 'TRL' and //n1:Invoice/cac:LegalMonetaryTotal/cbc:LineExtensionAmount/@currencyID != 'TRY'">
												<xsl:value-of
													select="//n1:Invoice/cac:LegalMonetaryTotal/cbc:LineExtensionAmount/@currencyID"
												/>
											</xsl:if>
										</xsl:if>
									</span>
								</td>
							</tr>
						</xsl:if>
					</xsl:for-each>
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
										test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:AllowanceTotalAmount/@currencyID = 'TRL' or //n1:Invoice/cac:LegalMonetaryTotal/cbc:AllowanceTotalAmount/@currencyID = 'TRY'">
										<xsl:text>TL</xsl:text>
									</xsl:if>
									<xsl:if
										test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:AllowanceTotalAmount/@currencyID != 'TRL' and //n1:Invoice/cac:LegalMonetaryTotal/cbc:AllowanceTotalAmount/@currencyID != 'TRY' ">
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
										<xsl:if test="../../cbc:TaxAmount/@currencyID = 'TRL' or ../../cbc:TaxAmount/@currencyID = 'TRY'">
											<xsl:text>TL</xsl:text>
										</xsl:if>
										<xsl:if test="../../cbc:TaxAmount/@currencyID != 'TRL' and ../../cbc:TaxAmount/@currencyID != 'TRY'">
											<xsl:value-of select="../../cbc:TaxAmount/@currencyID"/>
										</xsl:if>
									</xsl:if>
								</xsl:for-each>
							</td>
						</tr>
					</xsl:for-each>
					<xsl:for-each select="n1:Invoice/cac:TaxTotal/cac:TaxSubtotal">
						<xsl:if test="cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode = '4171'">
							<tr id="budgetContainerTr" align="right">
								<td id="budgetContainerDummyTd"/>
								<td id="lineTableBudgetTd" align="right" width="200px">
									<span style="font-weight:bold; ">
										<xsl:text>KDV Matrahı</xsl:text>
									</span>
								</td>
								<td id="lineTableBudgetTd" style="width:81px; " align="right">
									<span>
										<xsl:value-of
												select="format-number(sum(//n1:Invoice/cac:TaxTotal/cac:TaxSubtotal[cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode=0015]/cbc:TaxableAmount), '###.##0,00', 'european')"/>										
										<xsl:if
											test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:TaxInclusiveAmount/@currencyID">
											<xsl:text> </xsl:text>
											<xsl:if
												test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:TaxInclusiveAmount/@currencyID = 'TRL' or //n1:Invoice/cac:LegalMonetaryTotal/cbc:TaxInclusiveAmount/@currencyID = 'TRY'">
												<xsl:text>TL</xsl:text>
											</xsl:if>
											<xsl:if
												test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:TaxInclusiveAmount/@currencyID != 'TRL' and //n1:Invoice/cac:LegalMonetaryTotal/cbc:TaxInclusiveAmount/@currencyID != 'TRY'">
												<xsl:value-of
													select="//n1:Invoice/cac:LegalMonetaryTotal/cbc:TaxInclusiveAmount/@currencyID"
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
										<xsl:text>Tevkifat Dahil Toplam Tutar</xsl:text>
									</span>
								</td>
								<td id="lineTableBudgetTd" style="width:81px; " align="right">
									<span>
										<xsl:value-of
											select="format-number(//n1:Invoice/cac:LegalMonetaryTotal/cbc:TaxInclusiveAmount, '###.##0,00', 'european')"/>
										<xsl:if
											test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:TaxInclusiveAmount/@currencyID">
											<xsl:text> </xsl:text>
											<xsl:if
												test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:TaxInclusiveAmount/@currencyID = 'TRL' or //n1:Invoice/cac:LegalMonetaryTotal/cbc:TaxInclusiveAmount/@currencyID = 'TRY'">
												<xsl:text>TL</xsl:text>
											</xsl:if>
											<xsl:if
												test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:TaxInclusiveAmount/@currencyID != 'TRL' and //n1:Invoice/cac:LegalMonetaryTotal/cbc:TaxInclusiveAmount/@currencyID != 'TRY'">
												<xsl:value-of
													select="//n1:Invoice/cac:LegalMonetaryTotal/cbc:TaxInclusiveAmount/@currencyID"
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
										<xsl:text>Tevkifat Hariç Toplam Tutar</xsl:text>
									</span>
								</td>
								<td id="lineTableBudgetTd" style="width:81px; " align="right">
									<span>
										<xsl:value-of
											select="format-number(//n1:Invoice/cac:LegalMonetaryTotal/cbc:PayableAmount, '###.##0,00', 'european')"/>
										<xsl:if
											test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:PayableAmount/@currencyID">
											<xsl:text> </xsl:text>
											<xsl:if
												test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:PayableAmount/@currencyID = 'TRL' or //n1:Invoice/cac:LegalMonetaryTotal/cbc:PayableAmount/@currencyID = 'TRY'">
												<xsl:text>TL</xsl:text>
											</xsl:if>
											<xsl:if
												test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:PayableAmount/@currencyID != 'TRL' and //n1:Invoice/cac:LegalMonetaryTotal/cbc:PayableAmount/@currencyID != 'TRY'">
												<xsl:value-of
													select="//n1:Invoice/cac:LegalMonetaryTotal/cbc:PayableAmount/@currencyID"
												/>
											</xsl:if>
										</xsl:if>
									</span>
								</td>
							</tr>
						</xsl:if>						
					</xsl:for-each>
					<xsl:for-each select="n1:Invoice/cac:WithholdingTaxTotal/cac:TaxSubtotal">
						<tr id="budgetContainerTr" align="right">
							<td id="budgetContainerDummyTd"/>
							<td id="lineTableBudgetTd" width="211px" align="right">
								<span style="font-weight:bold; ">
									<xsl:text>Hesaplanan KDV Tevkifat</xsl:text>
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
										<xsl:if test="../../cbc:TaxAmount/@currencyID = 'TRL' or ../../cbc:TaxAmount/@currencyID = 'TRY'">
											<xsl:text>TL</xsl:text>
										</xsl:if>
										<xsl:if test="../../cbc:TaxAmount/@currencyID != 'TRL' and ../../cbc:TaxAmount/@currencyID != 'TRY'">
											<xsl:value-of select="../../cbc:TaxAmount/@currencyID"/>
										</xsl:if>
									</xsl:if>
								</xsl:for-each>
							</td>
						</tr>
					</xsl:for-each>
					<xsl:if
						test="sum(n1:Invoice/cac:TaxTotal/cac:TaxSubtotal[cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode=9015]/cbc:TaxableAmount)>0">
						<tr id="budgetContainerTr" align="right">
							<td id="budgetContainerDummyTd"/>
							<td id="lineTableBudgetTd" width="211px" align="right">
								<span style="font-weight:bold; ">
									<xsl:text>Tevkifata Tabi İşlem Tutarı</xsl:text>
								</span>
							</td>
							<td id="lineTableBudgetTd" style="width:82px; " align="right">
								<xsl:value-of
									select="format-number(sum(n1:Invoice/cac:InvoiceLine[cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode=9015]/cbc:LineExtensionAmount), '###.##0,00', 'european')"/>
								<xsl:if test="n1:Invoice/cbc:DocumentCurrencyCode = 'TRL'">
									<xsl:text>TL</xsl:text>
								</xsl:if>
								<xsl:if test="n1:Invoice/cbc:DocumentCurrencyCode != 'TRL'">
									<xsl:value-of select="n1:Invoice/cbc:DocumentCurrencyCode"/>
								</xsl:if>
							</td>
						</tr>
						<tr id="budgetContainerTr" align="right">
							<td id="budgetContainerDummyTd"/>
							<td id="lineTableBudgetTd" width="211px" align="right">
								<span style="font-weight:bold; ">
									<xsl:text>Tevkifata Tabi İşlem Üzerinden Hes. KDV</xsl:text>
								</span>
							</td>
							<td id="lineTableBudgetTd" style="width:82px; " align="right">
								<xsl:value-of
									select="format-number(sum(n1:Invoice/cac:TaxTotal/cac:TaxSubtotal[cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode=9015]/cbc:TaxableAmount), '###.##0,00', 'european')"/>
								<xsl:if test="n1:Invoice/cbc:DocumentCurrencyCode = 'TRL'">
									<xsl:text>TL</xsl:text>
								</xsl:if>
								<xsl:if test="n1:Invoice/cbc:DocumentCurrencyCode != 'TRL'">
									<xsl:value-of select="n1:Invoice/cbc:DocumentCurrencyCode"/>
								</xsl:if>
							</td>
						</tr>
					</xsl:if>					
					<xsl:if test = "n1:Invoice/cac:InvoiceLine[cac:WithholdingTaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme]">
						<tr id="budgetContainerTr" align="right">
							<td id="budgetContainerDummyTd"/>
							<td id="lineTableBudgetTd" width="211px" align="right">
								<span style="font-weight:bold; ">
									<xsl:text>Tevkifata Tabi İşlem Tutarı</xsl:text>
								</span>
							</td>
							<td id="lineTableBudgetTd" style="width:82px; " align="right">
								<xsl:if test = "n1:Invoice/cac:InvoiceLine[cac:WithholdingTaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme]">
									<xsl:value-of
										select="format-number(sum(n1:Invoice/cac:InvoiceLine[cac:WithholdingTaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme]/cbc:LineExtensionAmount), '###.##0,00', 'european')"/>
								</xsl:if>
								<xsl:if test = "//n1:Invoice/cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode=&apos;9015&apos;">
									<xsl:value-of
										select="format-number(sum(n1:Invoice/cac:InvoiceLine[cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode=9015]/cbc:LineExtensionAmount), '###.##0,00', 'european')"/>
								</xsl:if>								
								<xsl:if test="n1:Invoice/cbc:DocumentCurrencyCode = 'TRL' or n1:Invoice/cbc:DocumentCurrencyCode = 'TRY'">
									<xsl:text>TL</xsl:text>
								</xsl:if>
								<xsl:if test="n1:Invoice/cbc:DocumentCurrencyCode != 'TRL' and n1:Invoice/cbc:DocumentCurrencyCode != 'TRY'">
									<xsl:value-of select="n1:Invoice/cbc:DocumentCurrencyCode"/>
								</xsl:if>
							</td>
						</tr>
						<tr id="budgetContainerTr" align="right">
							<td id="budgetContainerDummyTd"/>
							<td id="lineTableBudgetTd" width="211px" align="right">
								<span style="font-weight:bold; ">
									<xsl:text>Tevkifata Tabi İşlem Üzerinden Hes. KDV</xsl:text>
								</span>
							</td>
							<td id="lineTableBudgetTd" style="width:82px; " align="right">
								<xsl:if test = "n1:Invoice/cac:InvoiceLine[cac:WithholdingTaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme]">
									<xsl:value-of
										select="format-number(sum(n1:Invoice/cac:WithholdingTaxTotal/cac:TaxSubtotal[cac:TaxCategory/cac:TaxScheme]/cbc:TaxableAmount), '###.##0,00', 'european')"/>
								</xsl:if>
								<xsl:if test = "//n1:Invoice/cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode=&apos;9015&apos;">
									<xsl:value-of
										select="format-number(sum(n1:Invoice/cac:TaxTotal/cac:TaxSubtotal[cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode=9015]/cbc:TaxableAmount), '###.##0,00', 'european')"/>
								</xsl:if>
								<xsl:if test="n1:Invoice/cbc:DocumentCurrencyCode = 'TRL' or n1:Invoice/cbc:DocumentCurrencyCode = 'TRY'">
									<xsl:text>TL</xsl:text>
								</xsl:if>
								<xsl:if test="n1:Invoice/cbc:DocumentCurrencyCode != 'TRL' and n1:Invoice/cbc:DocumentCurrencyCode != 'TRY'">
									<xsl:value-of select="n1:Invoice/cbc:DocumentCurrencyCode"/>
								</xsl:if>
							</td>
						</tr>
					</xsl:if>
					<tr id="budgetContainerTr" align="right">
						<td id="budgetContainerDummyTd"/>
						<td id="lineTableBudgetTd" width="200px" align="right">
							<span style="font-weight:bold; ">
								<xsl:text>Vergiler Dahil Toplam Tutar</xsl:text>
							</span>
						</td>
						<td id="lineTableBudgetTd" style="width:82px; " align="right">
							<xsl:value-of
								select="format-number(//n1:Invoice/cac:LegalMonetaryTotal/cbc:TaxInclusiveAmount, '###.##0,00', 'european')"/>
							<xsl:if
								test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:TaxInclusiveAmount/@currencyID">
								<xsl:text> </xsl:text>
								<xsl:if
									test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:TaxInclusiveAmount/@currencyID = 'TRL' or //n1:Invoice/cac:LegalMonetaryTotal/cbc:TaxInclusiveAmount/@currencyID = 'TRY'">
									<xsl:text>TL</xsl:text>
								</xsl:if>
								<xsl:if
									test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:TaxInclusiveAmount/@currencyID != 'TRL' and //n1:Invoice/cac:LegalMonetaryTotal/cbc:TaxInclusiveAmount/@currencyID != 'TRY'">
									<xsl:value-of
									select="//n1:Invoice/cac:LegalMonetaryTotal/cbc:TaxInclusiveAmount/@currencyID"
									/>
								</xsl:if>
							</xsl:if>
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
							<xsl:value-of
								select="format-number(//n1:Invoice/cac:LegalMonetaryTotal/cbc:PayableAmount, '###.##0,00', 'european')"/>
							<xsl:if
								test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:PayableAmount/@currencyID">
								<xsl:text> </xsl:text>
								<xsl:if
									test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:PayableAmount/@currencyID = 'TRL' or //n1:Invoice/cac:LegalMonetaryTotal/cbc:PayableAmount/@currencyID = 'TRY'">
									<xsl:text>TL</xsl:text>
								</xsl:if>
								<xsl:if
									test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:PayableAmount/@currencyID != 'TRL' and //n1:Invoice/cac:LegalMonetaryTotal/cbc:PayableAmount/@currencyID != 'TRY'">
									<xsl:value-of
									select="//n1:Invoice/cac:LegalMonetaryTotal/cbc:PayableAmount/@currencyID"
									/>
								</xsl:if>
							</xsl:if>
						</td>
					</tr>
					<xsl:if
						test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:LineExtensionAmount/@currencyID != 'TRL' and //n1:Invoice/cac:LegalMonetaryTotal/cbc:LineExtensionAmount/@currencyID != 'TRY'">
						<tr align="right">
							<td/>
							<td id="lineTableBudgetTd" align="right" width="200px">
								<span style="font-weight:bold; ">
									<xsl:text>Mal Hizmet Toplam Tutarı(TL)</xsl:text>
								</span>
							</td>
							<td id="lineTableBudgetTd" style="width:81px; " align="right">
								<span>
									<xsl:value-of
										select="format-number(//n1:Invoice/cac:LegalMonetaryTotal/cbc:LineExtensionAmount * //n1:Invoice/cac:PricingExchangeRate/cbc:CalculationRate, '###.##0,00', 'european')"/>
									<xsl:text> TL</xsl:text>
								</span>
							</td>
						</tr>
						<tr id="budgetContainerTr" align="right">
							<td/>
							<td id="lineTableBudgetTd" width="200px" align="right">
								<span style="font-weight:bold; ">
									<xsl:text>Vergiler Dahil Toplam Tutar(TL)</xsl:text>
								</span>
							</td>
							<td id="lineTableBudgetTd" style="width:82px; " align="right">
								<xsl:value-of
									select="format-number(//n1:Invoice/cac:LegalMonetaryTotal/cbc:TaxInclusiveAmount * //n1:Invoice/cac:PricingExchangeRate/cbc:CalculationRate, '###.##0,00', 'european')"/>
								<xsl:text> TL</xsl:text>
							</td>
						</tr>
						<tr align="right">
							<td/>
							<td id="lineTableBudgetTd" width="200px" align="right">
								<span style="font-weight:bold; ">
									<xsl:text>Ödenecek Tutar(TL)</xsl:text>
								</span>
							</td>
							<td id="lineTableBudgetTd" style="width:82px; " align="right">
								<xsl:value-of
									select="format-number(//n1:Invoice/cac:LegalMonetaryTotal/cbc:PayableAmount * //n1:Invoice/cac:PricingExchangeRate/cbc:CalculationRate, '###.##0,00', 'european')"/>
								<xsl:text> TL</xsl:text>
							</td>
						</tr>
					</xsl:if>
				</table>
				<br/>
				<table id="notesTable" width="800" align="left" height="100">
					<tbody>
						<tr align="left">
							<td id="notesTableTd">
								<xsl:for-each select="//n1:Invoice/cac:TaxTotal/cac:TaxSubtotal">
									<xsl:if
										test="cbc:Percent=0 and cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode=&apos;0015&apos;">
										<b>&#160;&#160;&#160;&#160;&#160; Vergi İstisna Muafiyet
											Sebebi: </b>
										<xsl:value-of
											select="cac:TaxCategory/cbc:TaxExemptionReason"/>
										<br/>
									</xsl:if>
								</xsl:for-each>
							<!--<xsl:if test="//n1:Invoice/cbc:Note">
									<b>&#160;&#160;&#160;&#160;&#160; Not: </b>
									<xsl:value-of select="//n1:Invoice/cbc:Note"/>
									<br/>
								</xsl:if>-->								
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
									<b>&#160;&#160;&#160;&#160;&#160; Ödeme Notu: </b>
									<xsl:value-of
										select="//n1:Invoice/cac:PaymentMeans/cbc:InstructionNote"/>
									<br/>
								</xsl:if>
								<xsl:if
									test="//n1:Invoice/cac:PaymentMeans/cac:PayeeFinancialAccount/cbc:PaymentNote">
									<b>&#160;&#160;&#160;&#160;&#160; Hesap Açıklaması: </b>
									<xsl:value-of
										select="//n1:Invoice/cac:PaymentMeans/cac:PayeeFinancialAccount/cbc:PaymentNote"/>
									<br/>
								</xsl:if>
								<xsl:if test="//n1:Invoice/cac:PaymentTerms/cbc:Note">
									<b>&#160;&#160;&#160;&#160;&#160; Ödeme Koşulu: </b>
									<xsl:value-of select="//n1:Invoice/cac:PaymentTerms/cbc:Note"/>
									<br/>
								</xsl:if>
								<br/>
								<br/>
								<xsl:text>Mindshare Medya Hizm A.Ş</xsl:text>
								<br/>
								<xsl:text>Banka Adı   Şube Adı    Hesap No  IBAN   Döviz Cinsi</xsl:text>
								<br/>
								<xsl:text>Yapıkredi Bankası	Merkez Şube	81859541	TR820006701000000081859541	TL</xsl:text>
								<br/>
								<xsl:text>Yapıkredi Bankası	Merkez Şube	81859561	TR270006701000000081859561	USD</xsl:text>
								<br/>
								<xsl:text>Yapıkredi Bankası	Merkez Şube	81859551	TR060006701000000081859551	EURO</xsl:text>
								<br/>
								<xsl:text>Yapıkredi Bankası	Merkez Şube	82230953	TR120006701000000082230953	GBP</xsl:text>
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
						select="format-number(./cbc:InvoicedQuantity, '###.###,####', 'european')"/>
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
								<xsl:when test="@unitCode  = 'ANN'">
									<span>
										<xsl:text> Yıl</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'HUR'">
									<span>
										<xsl:text> Saat</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'D61'">
									<span>
										<xsl:text> Dakika</xsl:text>
									</span>
								</xsl:when>
								<xsl:when test="@unitCode  = 'D62'">
									<span>
										<xsl:text> Saniye</xsl:text>
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
						select="format-number(./cac:Price/cbc:PriceAmount, '###.##0,########', 'european')"/>
					<xsl:if test="./cac:Price/cbc:PriceAmount/@currencyID">
						<xsl:text> </xsl:text>
						<xsl:if test="./cac:Price/cbc:PriceAmount/@currencyID = &quot;TRL&quot; or ./cac:Price/cbc:PriceAmount/@currencyID = &quot;TRY&quot;">
							<xsl:text>TL</xsl:text>
						</xsl:if>
						<xsl:if test="./cac:Price/cbc:PriceAmount/@currencyID != &quot;TRL&quot; and ./cac:Price/cbc:PriceAmount/@currencyID != &quot;TRY&quot;">
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
						<xsl:if test="./cac:AllowanceCharge/cbc:Amount/@currencyID = 'TRL' or ./cac:AllowanceCharge/cbc:Amount/@currencyID = 'TRY'">
							<xsl:text>TL</xsl:text>
						</xsl:if>
						<xsl:if test="./cac:AllowanceCharge/cbc:Amount/@currencyID != 'TRL' and ./cac:AllowanceCharge/cbc:Amount/@currencyID != 'TRY' ">
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
								<xsl:if test="../../cbc:TaxAmount/@currencyID = 'TRL' or ../../cbc:TaxAmount/@currencyID = 'TRY'">
									<xsl:text>TL</xsl:text>
								</xsl:if>
								<xsl:if test="../../cbc:TaxAmount/@currencyID != 'TRL' and ../../cbc:TaxAmount/@currencyID != 'TRY'">
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
									select="format-number(../../cbc:Percent, '###.##0,00', 'european')"/>
								<xsl:text>)=</xsl:text>
							</xsl:if>
							<xsl:value-of
								select="format-number(../../cbc:TaxAmount, '###.##0,00', 'european')"/>
							<xsl:if test="../../cbc:TaxAmount/@currencyID">
								<xsl:text> </xsl:text>
								<xsl:if test="../../cbc:TaxAmount/@currencyID = 'TRL' or ../../cbc:TaxAmount/@currencyID = 'TRY'">
									<xsl:text>TL</xsl:text><xsl:text>&#10;</xsl:text>
								</xsl:if>
								<xsl:if test="../../cbc:TaxAmount/@currencyID != 'TRL' and ../../cbc:TaxAmount/@currencyID != 'TRY'">
									<xsl:value-of select="../../cbc:TaxAmount/@currencyID"/><xsl:text>&#10;</xsl:text>
								</xsl:if>
							</xsl:if>
						</xsl:if>
					</xsl:for-each>
					<xsl:for-each
						select="./cac:WithholdingTaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme">
						<xsl:text>KDV TEVKİFAT </xsl:text>
							<xsl:if test="../../cbc:Percent">
								<xsl:text> (%</xsl:text>
								<xsl:value-of
									select="format-number(../../cbc:Percent, '###.##0,00', 'european')"/>
								<xsl:text>)=</xsl:text>
							</xsl:if>
							<xsl:value-of
								select="format-number(../../cbc:TaxAmount, '###.##0,00', 'european')"/>
							<xsl:if test="../../cbc:TaxAmount/@currencyID">
								<xsl:text> </xsl:text>
								<xsl:if test="../../cbc:TaxAmount/@currencyID = 'TRL' or ../../cbc:TaxAmount/@currencyID = 'TRY'">
									<xsl:text>TL</xsl:text><xsl:text>&#10;</xsl:text>
								</xsl:if>
								<xsl:if test="../../cbc:TaxAmount/@currencyID != 'TRL' and ../../cbc:TaxAmount/@currencyID != 'TRY'">
									<xsl:value-of select="../../cbc:TaxAmount/@currencyID"/><xsl:text>&#10;</xsl:text>
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
						<xsl:if test="./cbc:LineExtensionAmount/@currencyID = 'TRL' or ./cbc:LineExtensionAmount/@currencyID = 'TRY' ">
							<xsl:text>TL</xsl:text>
						</xsl:if>
						<xsl:if test="./cbc:LineExtensionAmount/@currencyID != 'TRL' and ./cbc:LineExtensionAmount/@currencyID != 'TRY'">
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
