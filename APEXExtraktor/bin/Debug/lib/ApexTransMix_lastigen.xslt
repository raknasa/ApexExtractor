<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:xlink="http://www.w3.org/1999/xlink" exclude-result-prefixes="xsl">
	<!--<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 
xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" 
xmlns:ms="http://www.test.com/schemas/test" 
xmlns:ns="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="ms ns xsi">-->
	<xsl:output method="xml" version="1.0" encoding="UTF-8" indent="yes"/>
	<xsl:template match="Apex">
		<ead xmlns="urn:isbn:1-931666-22-9" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xsi:schemaLocation="urn:isbn:1-931666-22-9 http://www.archivesportaleurope.net/Portal/profiles/apeEAD.xsd 
    http://www.w3.org/1999/xlink http://www.loc.gov/standards/xlink/xlink.xsd" xmlns:xlink="http://www.w3.org/1999/xlink" audience="external" xmlns:ns="urn:schemas-microsoft-com:xslt">
			<eadheader countryencoding="iso3166-1" dateencoding="iso8601" langencoding="iso639-2b" repositoryencoding="iso15511" scriptencoding="iso15924" relatedencoding="MARC21">
				<!-- <eadid> attributes: countrycode is two-letter country code according to ISO 3166-1; mainagencycode is the identifier of the institution, 
        starting with the country code plus a unit identifier, here "SA" has been chosen as in the Internet address of the Danish National Archives as an example, 
        needs to be compliant with ISO 15511, ideally a registered ISIL code; identifier combines the identifier of the institution with the identifier of the
        fonds/collection (or any subunit) that is described in the EAD finding aid -->
				<eadid countrycode="DK" identifier="DK-SA_448" mainagencycode="DK-SA">1</eadid>
				<filedesc>
					<titlestmt>
					<xsl:apply-templates select="ApexNg/HentNgNavn/NgNavn"/>
		
					<!--	<titleproper encodinganalog="245">Creator</titleproper>-->
					</titlestmt>
				</filedesc>
	
				<revisiondesc>
					<change>
						<date/>
						<item>Converted_apeEAD_version_1.2.5</item>
					</change>
				</revisiondesc>
			</eadheader>
			<archdesc level="fonds" type="inventory" encodinganalog="3.1.4" relatedencoding="ISAD(G)v2">
				<did>
				
					<unittitle encodinganalog="3.1.2">
					
						Apex test
					</unittitle>
				</did>
				<dsc type="othertype">
					<xsl:apply-templates select="//ApexNg"/>
				</dsc>
			</archdesc>
		</ead>
	</xsl:template>
	<xsl:template match="ApexNg/HentNgNavn/NgNavn">
		<titleproper encodinganalog="245"><xsl:value-of select="."/></titleproper></xsl:template>
	<xsl:template match="ApexNg">
		<c level="fonds">
			<xsl:attribute name="id">dk<xsl:value-of select="@id"/></xsl:attribute>
			<did>
				<unitid encodinganalog="3.1.1" type="call number">
					<extptr>
						<xsl:attribute name="xlink:href">http://www.sa.dk/content/dk/daisy/arkivskaber_detaljer?ngid=<xsl:value-of select="@id"/></xsl:attribute>
					</extptr>
				</unitid>
				<xsl:apply-templates select="NgInfo/Ng"/>
				<xsl:apply-templates select="HentNgNavn"/>
				<xsl:apply-templates select="NgDetaljer/Ng/Overordnet"/>
				<xsl:apply-templates select="NgDetaljer/Ng/Underordnet"/>
			</did>
			<scopecontent encodinganalog="summary">
				<p>
					<xsl:apply-templates select="NgDetaljer/Ng"/>
				</p>
			</scopecontent>
			<xsl:apply-templates select="ApexHe"/>
		</c>
	</xsl:template>
	<xsl:template match="ApexHe">
		<c level="series">
			<xsl:attribute name="id">ng<xsl:value-of select="ApexNgId"/>he<xsl:value-of select="ApexHeId"/></xsl:attribute>
			<did>
				<unitid encodinganalog="3.1.1" type="call number">
					<extptr>
						<xsl:attribute name="xlink:href">http://www.sa.dk/daisy/he?id=<xsl:value-of select="ApexHeId"/></xsl:attribute>
					</extptr>
				</unitid>
				<xsl:apply-templates select="HeInfoBund/Arkivskabere"/>
				<xsl:apply-templates select="HeInfoTop"/>
			</did>
			<scopecontent encodinganalog="summary">
				<p>
					<xsl:apply-templates select="HeInfoBund"/>
				</p>
			
			</scopecontent>
			<xsl:apply-templates select="ApexEP"/>
			<!--	 <xsl:apply-templates select="ApexME"/>-->
		</c>
	</xsl:template>
	<xsl:template match="HentNgNavn">
		<unittitle>
			<xsl:value-of select="NgNavn"/> arkiv
		</unittitle>
	</xsl:template>
	<xsl:template match="NgInfo/Ng">
		<xsl:apply-templates select="Navn"/>
		<xsl:apply-templates select="Proveniens"/>
	</xsl:template>
	<xsl:template match="Navn">
		<origination>
			<corpname>
			Arkivskaber navn,  <xsl:value-of select="@art"/>,  <xsl:value-of select="@fra"/> - <xsl:value-of select="@til"/>: <xsl:value-of select="."/>
			</corpname>
		</origination>
	</xsl:template>
	<xsl:template match="Proveniens">
		<origination>
			<corpname>
			Arkivnummer: <xsl:value-of select="."/>
			</corpname>
		</origination>
	</xsl:template>
	<xsl:template match="NgDetaljer/Ng">
		<xsl:value-of select="BemPub"/>
		
	</xsl:template>
	<xsl:template match="NgDetaljer/Ng/Overordnet">
		<origination>
			<corpname>
			Overordnet arkivskaber,  <xsl:value-of select="@art"/>, <xsl:value-of select="@fra"/> - <xsl:value-of select="@til"/>:  <xsl:value-of select="."/>
			</corpname>
		</origination>
	</xsl:template>
	<xsl:template match="NgDetaljer/Ng/Underordnet">
		<origination>
			<corpname>
			Underordnet arkivskaber, <xsl:value-of select="@art"/>,  <xsl:value-of select="@fra"/> - <xsl:value-of select="@til"/>:  <xsl:value-of select="."/>
			</corpname>
		</origination>
	</xsl:template>
	<xsl:template match="HeInfoBund">
		<xsl:value-of select="PubBem"/>
	</xsl:template>
	<xsl:template match="HeInfoTop">
		<unittitle>
			<xsl:value-of select="Fra"/> - <xsl:value-of select="Til"/> : <xsl:value-of select="Navn"/>
		</unittitle>
		<xsl:if test="Til">
			<unitdate>
				<xsl:attribute name="normal"><xsl:value-of select="Fra"/>/<xsl:value-of select="Til"/></xsl:attribute>
				<xsl:value-of select="Fra"/> - <xsl:value-of select="Til"/>
			</unitdate>
		</xsl:if>
	</xsl:template>
	<xsl:template match="HeInfoBund/Arkivskabere">
		<xsl:apply-templates select="Ng"/>
	</xsl:template>
	<xsl:template match="Ng">
		<origination>
			<corpname>
			Fra: <xsl:value-of select="Fra"/> Til: <xsl:value-of select="Til"/> : <xsl:value-of select="Prefix"/>, <xsl:value-of select="Navn"/>
			</corpname>
		</origination>
	</xsl:template>
	<xsl:template match="ApexEP/HeEksemplarInfo">
		<xsl:apply-templates select="Eksemplar"/>
	</xsl:template>
	<xsl:template match="Eksemplar">
		<xsl:value-of select="EnhedNavne"/>, <xsl:value-of select="FormaalArt"/>, <xsl:value-of select="MedieArt"/>
	</xsl:template>
	<xsl:template match="ApexEP">
		<c level="subseries">
			<xsl:attribute name="id">ng<xsl:value-of select="@nid"/>he<xsl:value-of select="@hid"/>epf<xsl:value-of select="@epid"/></xsl:attribute>
			<did>
				<unitid encodinganalog="3.1.1" type="call number">
					<extptr>
						<xsl:attribute name="xlink:href">http://www.sa.dk/content/dk/daisy/fysiske_enheder_liste?epid=<xsl:value-of select="@epid"/></xsl:attribute>
					</extptr>
				</unitid>
			<xsl:apply-templates select="ApexEPInfo"/>
			</did>
			<xsl:apply-templates select="ApexME"/>
		</c>
	</xsl:template>
	<xsl:template match="ApexEPInfo">
	<!--	<xsl:apply-templates></xsl:apply-templates>-->
	<unittitle>
					<xsl:value-of select="FormaalArt"/>
				</unittitle>

	<physdesc >
	<xsl:value-of select="MedieArt"/>

</physdesc> 
	<repository>
	<xsl:value-of select="EnhedNavne"/>
</repository>
	</xsl:template>
	<xsl:template match="ApexME">
		<c level="item">
			<xsl:attribute name="id">ng<xsl:value-of select="@ngid"/>he<xsl:value-of select="@heid"/>rif<xsl:value-of select="@m2rid"/></xsl:attribute>
			<did>
				<unitid encodinganalog="3.1.1" type="call number">
					<extptr>
						<xsl:attribute name="xlink:href">http://www.sa.dk/content/dk/daisy/fysiske_enheder_detaljer?m2rid=<xsl:value-of select="@m2rid"/></xsl:attribute>
					</extptr>
				</unitid>
				<xsl:apply-templates select="MeDetaljer"/>
			</did>
		</c>
	</xsl:template>
	<xsl:template match="MeDetaljer">
		
		<unittitle>
		  	<xsl:value-of select="IndholdFra"/> - <xsl:value-of select="IndholdTil"/>
			
		</unittitle>
			<repository>
	<xsl:value-of select="Enhed"/>
</repository>
<physdesc >
 <xsl:value-of select="Formaalart"/>, 	<xsl:value-of select="Medieart"/>
 <xsl:apply-templates select="EtiketOpl/LbNr"/>
</physdesc> 
		
		
	</xsl:template>
	<xsl:template match="EtiketOpl/LbNr">
		
	<!--	<physdesc>-->
		Nr:
			<xsl:value-of select="."/>
	<!--	</physdesc>-->
		
	</xsl:template>
</xsl:stylesheet>
