USE [SEGURIMAX02]
GO
/****** Object:  StoredProcedure [dbo].[Consulta_SFS_DPA]    Script Date: 20/12/2021 11:05:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Consulta_SFS_DPA]
@DocEntry int
AS
BEGIN
SELECT
	CASE
		WHEN DocDate = DocDueDate
		THEN NULL
		ELSE CONVERT(numeric(18,2),DocTotal)
	END AS 'mtoCuotaPago',
	CASE
		WHEN DocDate=DocDueDate
		THEN NULL
		ELSE CONVERT(varchar,CONVERT(DATE,DocDueDate))
		END AS 'fecCuotaPago',
		CASE
		WHEN DocDate=DocDueDate
		THEN NULL
		ELSE 'PEN'
		END AS 'tipMonedaCuotaPago'
FROM OINV WHERE DocEntry = @DocEntry
END
GO
/****** Object:  StoredProcedure [dbo].[Consulta_SFS_PAG]    Script Date: 20/12/2021 11:05:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Consulta_SFS_PAG]
	@DocEntry int
AS
BEGIN
	SELECT 
	CASE
	WHEN DocDate=DocDueDate 
		THEN 'Contado'
		ELSE 'Credito'
	END
	AS 'formaPago',
	CASE
	WHEN DocDate=DocDueDate
	THEN 0
	ELSE CONVERT(numeric(18,2),DocTotal)
	END
	AS'mtoNetoPendientePago',
	'PEN'
	FROM OINV WHERE DocEntry = @DocEntry
END
GO
