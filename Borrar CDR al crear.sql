
-- BORRA DATOS DE CDR DE FACTURA
IF @object_type = '13' AND @transaction_type ='A'
BEGIN
	UPDATE OINV 
		SET
		U_ResponseCode = '',
		U_Description = '',
		U_DigestValue=''
		 WHERE DocEntry = @list_of_cols_val_tab_del
END

-- BORRA DATOS DE CDR DE NC
IF @object_type = '14' AND @transaction_type ='A'
BEGIN
	UPDATE ORIN 
		SET
		U_ResponseCode = '',
		U_Description = '',
		U_DigestValue=''
		 WHERE DocEntry = @list_of_cols_val_tab_del
END
-- BORRA DATOS DE CDR DE GR
IF @object_type = '15' AND @transaction_type ='A'
BEGIN
	UPDATE ODLN 
		SET
		U_ResponseCode = '',
		U_Description = '',
		U_DigestValue=''
		 WHERE DocEntry = @list_of_cols_val_tab_del
END

