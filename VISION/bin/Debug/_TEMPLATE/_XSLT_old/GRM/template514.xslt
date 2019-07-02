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
								 <!--
									<td width="60%" align="right" valign="middle">
									<br/>
									<br/>
									<img  align="middle" alt="E-Fatura Logo"
										src="data:image/png;base64,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"/>

									<h1 align="center">
										<span style="font-weight:bold; ">
											<xsl:text></xsl:text>
										</span>
									</h1>
								</td>
						        -->
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
