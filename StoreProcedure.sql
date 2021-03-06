USE [SEGURIMAX02]
GO
/****** Object:  StoredProcedure [dbo].[Consulta_NombreNC]    Script Date: 26/05/2021 01:29:17 ******/
DROP PROCEDURE [dbo].[Consulta_NombreNC]
GO
/****** Object:  StoredProcedure [dbo].[Consulta_NombreGuia]    Script Date: 26/05/2021 01:29:17 ******/
DROP PROCEDURE [dbo].[Consulta_NombreGuia]
GO
/****** Object:  StoredProcedure [dbo].[Consulta_NombreFactura]    Script Date: 26/05/2021 01:29:17 ******/
DROP PROCEDURE [dbo].[Consulta_NombreFactura]
GO
/****** Object:  StoredProcedure [dbo].[Consulta_Datos_Reporte_NC]    Script Date: 26/05/2021 01:29:17 ******/
DROP PROCEDURE [dbo].[Consulta_Datos_Reporte_NC]
GO
/****** Object:  StoredProcedure [dbo].[Consulta_Datos_Reporte_GR]    Script Date: 26/05/2021 01:29:17 ******/
DROP PROCEDURE [dbo].[Consulta_Datos_Reporte_GR]
GO
/****** Object:  StoredProcedure [dbo].[Consulta_Datos_Reporte_FT]    Script Date: 26/05/2021 01:29:17 ******/
DROP PROCEDURE [dbo].[Consulta_Datos_Reporte_FT]
GO
/****** Object:  StoredProcedure [dbo].[Actualizar_Rpta_Xml_NC]    Script Date: 26/05/2021 01:29:17 ******/
DROP PROCEDURE [dbo].[Actualizar_Rpta_Xml_NC]
GO
/****** Object:  StoredProcedure [dbo].[Actualizar_Rpta_Xml_GR]    Script Date: 26/05/2021 01:29:17 ******/
DROP PROCEDURE [dbo].[Actualizar_Rpta_Xml_GR]
GO
/****** Object:  StoredProcedure [dbo].[Actualizar_Rpta_Xml]    Script Date: 26/05/2021 01:29:17 ******/
DROP PROCEDURE [dbo].[Actualizar_Rpta_Xml]
GO
/****** Object:  StoredProcedure [dbo].[Actualizar_Rpta_Cdr_NC]    Script Date: 26/05/2021 01:29:17 ******/
DROP PROCEDURE [dbo].[Actualizar_Rpta_Cdr_NC]
GO
/****** Object:  StoredProcedure [dbo].[Actualizar_Rpta_Cdr_GR]    Script Date: 26/05/2021 01:29:17 ******/
DROP PROCEDURE [dbo].[Actualizar_Rpta_Cdr_GR]
GO
/****** Object:  StoredProcedure [dbo].[Actualizar_Rpta_Cdr]    Script Date: 26/05/2021 01:29:17 ******/
DROP PROCEDURE [dbo].[Actualizar_Rpta_Cdr]
GO
/****** Object:  StoredProcedure [dbo].[Actualizar_Rpta_Cdr]    Script Date: 26/05/2021 01:29:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Actualizar_Rpta_Cdr]
@Docentry int,
@U_ResponseCode varchar(2),
@U_Description varchar(50),
@U_DigestValue  varchar(max)
AS
BEGIN

UPDATE OINV	
SET U_ResponseCode = @U_ResponseCode, 
	U_Description = @U_Description,
	U_DigestValue = @U_DigestValue
WHERE DocEntry = @Docentry
END
GO
/****** Object:  StoredProcedure [dbo].[Actualizar_Rpta_Cdr_GR]    Script Date: 26/05/2021 01:29:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Actualizar_Rpta_Cdr_GR]
@Docentry int,
@U_ResponseCode varchar(2),
@U_Description varchar(50),
@U_DigestValue varchar(250)
AS
BEGIN

UPDATE ODLN	
SET U_ResponseCode = @U_ResponseCode, U_Description = @U_Description, U_DigestValue = @U_DigestValue
WHERE DocEntry = @Docentry
END
GO
/****** Object:  StoredProcedure [dbo].[Actualizar_Rpta_Cdr_NC]    Script Date: 26/05/2021 01:29:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Actualizar_Rpta_Cdr_NC]
@Docentry int,
@U_ResponseCode varchar(2),
@U_Description varchar(50),
@U_DigestValue varchar(max)
AS
BEGIN

UPDATE ORIN	
SET U_ResponseCode = @U_ResponseCode, U_Description = @U_Description,U_DigestValue = @U_DigestValue
WHERE DocEntry = @Docentry
END
GO
/****** Object:  StoredProcedure [dbo].[Actualizar_Rpta_Xml]    Script Date: 26/05/2021 01:29:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Actualizar_Rpta_Xml]
@Docentry int,
@U_DigestValue varchar(max)
AS
BEGIN

UPDATE OINV	
SET	U_DigestValue = @U_DigestValue
WHERE DocEntry = @Docentry
END
GO
/****** Object:  StoredProcedure [dbo].[Actualizar_Rpta_Xml_GR]    Script Date: 26/05/2021 01:29:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[Actualizar_Rpta_Xml_GR]
@Docentry int,
@U_DigestValue varchar(max)
AS
BEGIN

UPDATE ODLN	
SET	U_DigestValue = @U_DigestValue
WHERE DocEntry = @Docentry
END
GO
/****** Object:  StoredProcedure [dbo].[Actualizar_Rpta_Xml_NC]    Script Date: 26/05/2021 01:29:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[Actualizar_Rpta_Xml_NC]
@Docentry int,
@U_DigestValue varchar(max)
AS
BEGIN

UPDATE ORIN	
SET	U_DigestValue = @U_DigestValue
WHERE DocEntry = @Docentry
END
GO
/****** Object:  StoredProcedure [dbo].[Consulta_Datos_Reporte_FT]    Script Date: 26/05/2021 01:29:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Consulta_Datos_Reporte_FT]
@DocEntry int
AS
BEGIN
	SELECT T0.RevOffice AS RucEmi,T0.CompnyName as NomEmi,T0.CompnyAddr as DirEmi,T1.ZipCode,
		T2.LicTradNum,T2.CardName,t2.Address,
		CONVERT(VARCHAR,t2.DocDate,103)AS DocDate,CONVERT(VARCHAR,t2.TaxDate,103) AS TaxDate,t2.U_DigestValue,t4.SeriesName+'-'+convert(varchar,t2.FolioNum) as NumCor,
		t2.GrosProfit,t2.VatSum,t2.DocTotal,dbo.CantidadConLetra(CONVERT(money,T2.DocTotal)) as DocTotalLetras,
		/*DETALLE*/
		T3.ItemCode,CONVERT(INT,T3.Quantity)AS Quantity,T3.unitMsr,T3.Dscription,t3.Price,t3.PriceAfVAT, t3.LineTotal

	FROM OADM T0
	CROSS JOIN ADM1 T1
	CROSS JOIN OINV T2 
	LEFT JOIN INV1 T3 ON T2.DocEntry = T3.DocEntry
	LEFT JOIN NNM1 T4 ON T2.Series = T4.Series

	WHERE T2.DocEntry = @DocEntry

END
GO
/****** Object:  StoredProcedure [dbo].[Consulta_Datos_Reporte_GR]    Script Date: 26/05/2021 01:29:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Consulta_Datos_Reporte_GR]
@DocEntry int
AS
BEGIN
	SELECT T0.RevOffice AS RucEmi,T0.CompnyName as NomEmi,T0.CompnyAddr as DirEmi,T1.ZipCode,
		T2.LicTradNum,T2.CardName,'VENTA' AS MotTras,t2.Address2,
		CONVERT(VARCHAR,t2.DocDate,103)AS DocDate,CONVERT(VARCHAR,t2.TaxDate,103) AS TaxDate,'Transporte privado' as'TransPrivado',
		'AES-390' as PlaTra, '46757706' as NumLic, 'Juan C.' as NomCon,t2.U_DigestValue,t4.SeriesName+'-'+convert(varchar,t2.FolioNum) as NumCor,
		/*DETALLE*/
		T3.ItemCode,CONVERT(INT,T3.Quantity)AS Quantity,T3.unitMsr,T3.Dscription

	FROM OADM T0
	CROSS JOIN ADM1 T1
	CROSS JOIN ODLN T2 
	LEFT JOIN DLN1 T3 ON T2.DocEntry = T3.DocEntry
	LEFT JOIN NNM1 T4 ON T2.Series = T4.Series

	WHERE T2.DocEntry = @DocEntry

END
GO
/****** Object:  StoredProcedure [dbo].[Consulta_Datos_Reporte_NC]    Script Date: 26/05/2021 01:29:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Consulta_Datos_Reporte_NC]
@DocEntry int
AS
BEGIN
DECLARE @DocEntryFac int
DECLARE @SerieNumFac varchar(20)

SET @DocEntryFac = (SELECT top 1 BaseEntry FROM RIN1 WHERE DocEntry = @DocEntry)

SET @SerieNumFac = (SELECT T1.SeriesName+'-'+convert(varchar,T0.FolioNum) FROM OINV T0 INNER JOIN NNM1 T1 ON T0.Series = T1.Series WHERE T0.DocEntry = @DocEntryFac)

	SELECT T0.RevOffice AS RucEmi,T0.CompnyName as NomEmi,T0.CompnyAddr as DirEmi,T1.ZipCode,
		T2.LicTradNum,T2.CardName,t2.Address,
		CONVERT(VARCHAR,t2.DocDate,103)AS DocDate,CONVERT(VARCHAR,t2.TaxDate,103) AS TaxDate,t2.U_DigestValue,t4.SeriesName+'-'+convert(varchar,t2.FolioNum) as NumCor,
		t2.GrosProfit,t2.VatSum,t2.DocTotal,dbo.CantidadConLetra(CONVERT(money,T2.DocTotal)) as DocTotalLetras,
		@SerieNumFac as DocRef,(SELECT Name FROM [@TIPNOCR] where Code = t2.U_TipNotCre) as TipNot,
		/*DETALLE*/
		T3.ItemCode,CONVERT(INT,T3.Quantity)AS Quantity,T3.unitMsr,T3.Dscription,t3.Price,t3.PriceAfVAT, t3.LineTotal

	FROM OADM T0
	CROSS JOIN ADM1 T1
	CROSS JOIN ORIN T2 
	LEFT JOIN RIN1 T3 ON T2.DocEntry = T3.DocEntry
	LEFT JOIN NNM1 T4 ON T2.Series = T4.Series


	WHERE T2.DocEntry = @DocEntry

END
GO
/****** Object:  StoredProcedure [dbo].[Consulta_NombreFactura]    Script Date: 26/05/2021 01:29:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Consulta_NombreFactura] 
	
@DocEntry int
AS
BEGIN
	SELECT T0.LicTradNum,T0.CardName, T1.SeriesName,T0.FolioNum
FROM OINV T0
LEFT JOIN NNM1 T1 ON T1.Series = T0.Series
WHERE T0.DocEntry = @DocEntry
END
GO
/****** Object:  StoredProcedure [dbo].[Consulta_NombreGuia]    Script Date: 26/05/2021 01:29:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[Consulta_NombreGuia] 
	
@DocEntry int
AS
BEGIN
	SELECT T0.LicTradNum,T0.CardName, T1.SeriesName,T0.FolioNum
FROM ODLN T0
LEFT JOIN NNM1 T1 ON T1.Series = T0.Series
WHERE T0.DocEntry = @DocEntry
END
GO
/****** Object:  StoredProcedure [dbo].[Consulta_NombreNC]    Script Date: 26/05/2021 01:29:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[Consulta_NombreNC] 
	
@DocEntry int
AS
BEGIN
	SELECT T0.LicTradNum,T0.CardName, T1.SeriesName,T0.FolioNum
FROM ORIN T0
LEFT JOIN NNM1 T1 ON T1.Series = T0.Series
WHERE T0.DocEntry = @DocEntry
END
GO
