DROP TABLE SQMNUC.LOG_POS_SERV_HIST;

CREATE TABLE "SQMNUC  "."LOG_POS_SERV_HIST"  (
		  "LOGPO_IDSESION" INTEGER ,
		  "LOGPO_CMCIO_ID" INTEGER ,
		  "LOGPO_SERVI_CODIGO" INTEGER ,
		  "LOGPO_FECHAYHORA" TIMESTAMP ,
		  "LOGPO_CANAL" INTEGER ,
		  "LOGPO_ORIGEN" INTEGER ,
		  "LOGPO_CMCIOPOS_CODIGO" CHAR(9) ,
		  "LOGPO_CMCIO_CODIGO" CHAR(15) ,
		  "LOGPO_CMCIO_CODGESTION" CHAR(9) ,
		  "LOGPO_NRO_POS" CHAR(8) ,
		  "LOGPO_ID_TRANSACCION" CHAR(6) ,
		  "LOGPO_NRO_TRACE" CHAR(6) ,
		  "LOGPO_TIPO_OPERACION" CHAR(1) ,
		  "LOGPO_FECHAHORA_TRAN" CHAR(12) ,
		  "LOGPO_MONEDA" CHAR(3) ,
		  "LOGPO_CODRESPUESTA" CHAR(3) ,
		  "LOGPO_DATOS_PRODUCTO" VARCHAR(300) ,
		  "LOGPO_CMCIOPOS_NOMBRE" CHAR(40) ,
		  "LOGPO_IMPORTE_PEDIDO" BIGINT ,
		  "LOGPO_NRO_PEDIDO" CHAR(20) ,
		  "LOGPO_LOCAL_CODIGO" INTEGER ,
		  "LOGPO_ESTADO_PEDIDO" CHAR(2) ,
		  "LOGPO_TIPO_COMANDO" CHAR(2) ,
		  "LOGPO_FORMA_PAGO" CHAR(1) ,
		  "LOGPO_EST_PASARELA" CHAR(2) ,
		  "LOGPO_NRO_TARJETA" CHAR(20) ,
		  "LOGPO_FECHA_VENC" CHAR(4) ,
		  "LOGPO_CODRETO_CMCIO" CHAR(2) ,
		  "LOGPO_CODRETO_DESC" CHAR(50) ,
		  "LOGPO_DATOSAPP1" VARCHAR(40) WITH DEFAULT '' ,
		  "LOGPO_DATOSAPP2" VARCHAR(40) WITH DEFAULT '' ,
		  "LOGPO_DATOSAPP3" VARCHAR(40) WITH DEFAULT '' ,
		  "LOGPO_DATOSAPP4" VARCHAR(40) WITH DEFAULT '' ,
		  "LOGPO_DATOSAPP5" VARCHAR(40) WITH DEFAULT '' ,
		  "LOGPO_ESTADO_CIERRE" CHAR(1) WITH DEFAULT '' ,
		  "LOGPO_COD_AUTORIZACION" CHAR(6) WITH DEFAULT '' ,
		  "LOGPO_ID_MOVIMIENTO" DECIMAL(9,0) NOT NULL ,
		  "LOGPO_DATOSAPP6" VARCHAR(40) WITH DEFAULT '' ,
		  "LOGPO_DATOSAPP7" VARCHAR(40) WITH DEFAULT '' ,
		  "LOGPO_DATOSAPP8" VARCHAR(40) WITH DEFAULT '' ,
		  "LOGPO_DATOSAPP9" VARCHAR(40) WITH DEFAULT '' ,
		  "LOGPO_DATOSAPP10" VARCHAR(40) WITH DEFAULT '' ,
		  "LOGPO_ID_TRAN_ANULA" CHAR(6) WITH DEFAULT '' ,
		  "LOGPO_VISOR" VARCHAR(64) WITH DEFAULT '',
		  "LOGPO_VOUCHER" VARCHAR(500) WITH DEFAULT '' ,
		  "LOGPO_RESOLUTOR" VARCHAR(100) WITH DEFAULT '' )
		 IN "USERSPACE1" ;

CREATE INDEX SQMNUC.IDX_HIST_FECHAYHORA ON SQMNUC.LOG_POS_SERV_HIST
("LOGPO_FECHAYHORA" ASC)
PCTFREE 10 MINPCTUSED 10
COMPRESS NO DISALLOW REVERSE SCANS;

-- Sentencias DDL para índices en tabla "SQMNUC  "."LOG_POS_SERV"
CREATE INDEX SQMNUC.IDX_HIST_IDMOV ON SQMNUC.LOG_POS_SERV_HIST
("LOGPO_ID_MOVIMIENTO" ASC)
PCTFREE 10 MINPCTUSED 10
COMPRESS NO DISALLOW REVERSE SCANS;

CREATE INDEX SQMNUC.IDX_HIST_CMCIOID ON SQMNUC.LOG_POS_SERV_HIST
("LOGPO_CMCIO_ID" ASC)
PCTFREE 10 MINPCTUSED 10
COMPRESS NO DISALLOW REVERSE SCANS;

CREATE INDEX SQMNUC.IDX_HIST_SERVI ON SQMNUC.LOG_POS_SERV_HIST
("LOGPO_SERVI_CODIGO" ASC)
PCTFREE 10 MINPCTUSED 10
COMPRESS NO DISALLOW REVERSE SCANS;

RUNSTATS ON TABLE SQMNUC.LOG_POS_SERV_HIST ON ALL COLUMNS;
RUNSTATS ON TABLE SQMNUC.LOG_POS_SERV_HIST FOR INDEXES ALL;

-----------------------------------------------------------------------------------
--EXPORTACION DE LA DATA
-----------------------------------------------------------------------------------
EXPORT TO "D:\LPS_2000_2005.ixf" OF IXF MESSAGES "D:\LPS_2004.txt" SELECT * FROM SQMNUC.LOG_POS_SERV WHERE LOGPO_FECHAYHORA > TIMESTAMP_ISO('2000-01-01') AND LOGPO_FECHAYHORA < TIMESTAMP_ISO('2005-01-01') ORDER BY LOGPO_FECHAYHORA;
COMMIT WORK;

EXPORT TO "D:\LPS_2005_2006.ixf" OF IXF MESSAGES "D:\LPS_2005.txt" SELECT * FROM SQMNUC.LOG_POS_SERV WHERE LOGPO_FECHAYHORA > TIMESTAMP_ISO('2005-01-01') AND LOGPO_FECHAYHORA < TIMESTAMP_ISO('2006-01-01') ORDER BY LOGPO_FECHAYHORA;
EXPORT TO "D:\LPS_2006_2007.ixf" OF IXF MESSAGES "D:\LPS_2006.txt" SELECT * FROM SQMNUC.LOG_POS_SERV WHERE LOGPO_FECHAYHORA > TIMESTAMP_ISO('2006-01-01') AND LOGPO_FECHAYHORA < TIMESTAMP_ISO('2007-01-01') ORDER BY LOGPO_FECHAYHORA;
EXPORT TO "D:\LPS_2007_2008.ixf" OF IXF MESSAGES "D:\LPS_2007.txt" SELECT * FROM SQMNUC.LOG_POS_SERV WHERE LOGPO_FECHAYHORA > TIMESTAMP_ISO('2007-01-01') AND LOGPO_FECHAYHORA < TIMESTAMP_ISO('2008-01-01') ORDER BY LOGPO_FECHAYHORA;
EXPORT TO "D:\LPS_2008_2009.ixf" OF IXF MESSAGES "D:\LPS_2008.txt" SELECT * FROM SQMNUC.LOG_POS_SERV WHERE LOGPO_FECHAYHORA > TIMESTAMP_ISO('2008-01-01') AND LOGPO_FECHAYHORA < TIMESTAMP_ISO('2009-01-01') ORDER BY LOGPO_FECHAYHORA;
EXPORT TO "D:\LPS_2009_2010.ixf" OF IXF MESSAGES "D:\LPS_2009.txt" SELECT * FROM SQMNUC.LOG_POS_SERV WHERE LOGPO_FECHAYHORA > TIMESTAMP_ISO('2009-01-01') AND LOGPO_FECHAYHORA < TIMESTAMP_ISO('2010-01-01') ORDER BY LOGPO_FECHAYHORA;
EXPORT TO "D:\LPS_2010_2011.ixf" OF IXF MESSAGES "D:\LPS_2010.txt" SELECT * FROM SQMNUC.LOG_POS_SERV WHERE LOGPO_FECHAYHORA > TIMESTAMP_ISO('2010-01-01') AND LOGPO_FECHAYHORA < TIMESTAMP_ISO('2011-01-01') ORDER BY LOGPO_FECHAYHORA;
EXPORT TO "D:\LPS_2011_2012.ixf" OF IXF MESSAGES "D:\LPS_2011.txt" SELECT * FROM SQMNUC.LOG_POS_SERV WHERE LOGPO_FECHAYHORA > TIMESTAMP_ISO('2011-01-01') AND LOGPO_FECHAYHORA < TIMESTAMP_ISO('2012-01-01') ORDER BY LOGPO_FECHAYHORA;
EXPORT TO "D:\LPS_2012_2013.ixf" OF IXF MESSAGES "D:\LPS_2012.txt" SELECT * FROM SQMNUC.LOG_POS_SERV WHERE LOGPO_FECHAYHORA > TIMESTAMP_ISO('2012-01-01') AND LOGPO_FECHAYHORA < TIMESTAMP_ISO('2013-01-01') ORDER BY LOGPO_FECHAYHORA;
EXPORT TO "D:\LPS_2013_2014.ixf" OF IXF MESSAGES "D:\LPS_2013.txt" SELECT * FROM SQMNUC.LOG_POS_SERV WHERE LOGPO_FECHAYHORA > TIMESTAMP_ISO('2013-01-01') AND LOGPO_FECHAYHORA < TIMESTAMP_ISO('2014-01-01') ORDER BY LOGPO_FECHAYHORA;
EXPORT TO "D:\LPS_2014_2015.ixf" OF IXF MESSAGES "D:\LPS_2014.txt" SELECT * FROM SQMNUC.LOG_POS_SERV WHERE LOGPO_FECHAYHORA > TIMESTAMP_ISO('2014-01-01') AND LOGPO_FECHAYHORA < TIMESTAMP_ISO('2015-01-01') ORDER BY LOGPO_FECHAYHORA;
--EXPORT TO "D:\LPS_2015_2016.ixf" OF IXF MESSAGES "D:\LPS_2015.txt" SELECT * FROM SQMNUC.LOG_POS_SERV WHERE LOGPO_FECHAYHORA > TIMESTAMP_ISO('2015-01-01') AND LOGPO_FECHAYHORA < TIMESTAMP_ISO('2016-01-01') ORDER BY LOGPO_FECHAYHORA;

-----------------------------------------------------------------------------------
--IMPORTACION DE LA DATA
-----------------------------------------------------------------------------------
LOAD FROM "D:\LPS_2000_2005.ixf" OF IXF METHOD P (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46)
MESSAGES "D:\LPS_2000_2005_Load.txt"
INSERT INTO SQMNUC.LOG_POS_SERV_HIST (LOGPO_IDSESION, LOGPO_CMCIO_ID, LOGPO_SERVI_CODIGO, LOGPO_FECHAYHORA, LOGPO_CANAL, LOGPO_ORIGEN, LOGPO_CMCIOPOS_CODIGO, LOGPO_CMCIO_CODIGO, LOGPO_CMCIO_CODGESTION, LOGPO_NRO_POS, LOGPO_ID_TRANSACCION, LOGPO_NRO_TRACE, LOGPO_TIPO_OPERACION, LOGPO_FECHAHORA_TRAN, LOGPO_MONEDA, LOGPO_CODRESPUESTA, LOGPO_DATOS_PRODUCTO, LOGPO_CMCIOPOS_NOMBRE, LOGPO_IMPORTE_PEDIDO, LOGPO_NRO_PEDIDO, LOGPO_LOCAL_CODIGO, LOGPO_ESTADO_PEDIDO, LOGPO_TIPO_COMANDO, LOGPO_FORMA_PAGO, LOGPO_EST_PASARELA, LOGPO_NRO_TARJETA, LOGPO_FECHA_VENC, LOGPO_CODRETO_CMCIO, LOGPO_CODRETO_DESC, LOGPO_DATOSAPP1, LOGPO_DATOSAPP2, LOGPO_DATOSAPP3, LOGPO_DATOSAPP4, LOGPO_DATOSAPP5, LOGPO_ESTADO_CIERRE, LOGPO_COD_AUTORIZACION, LOGPO_ID_MOVIMIENTO, LOGPO_DATOSAPP6, LOGPO_DATOSAPP7, LOGPO_DATOSAPP8, LOGPO_DATOSAPP9, LOGPO_DATOSAPP10, LOGPO_ID_TRAN_ANULA, LOGPO_VISOR, LOGPO_VOUCHER, LOGPO_RESOLUTOR) NONRECOVERABLE INDEXING MODE AUTOSELECT;

LOAD FROM "D:\LPS_2005_2006.ixf" OF IXF METHOD P (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46)
MESSAGES "D:\LPS_2005_2006_Load.txt"
INSERT INTO SQMNUC.LOG_POS_SERV_HIST (LOGPO_IDSESION, LOGPO_CMCIO_ID, LOGPO_SERVI_CODIGO, LOGPO_FECHAYHORA, LOGPO_CANAL, LOGPO_ORIGEN, LOGPO_CMCIOPOS_CODIGO, LOGPO_CMCIO_CODIGO, LOGPO_CMCIO_CODGESTION, LOGPO_NRO_POS, LOGPO_ID_TRANSACCION, LOGPO_NRO_TRACE, LOGPO_TIPO_OPERACION, LOGPO_FECHAHORA_TRAN, LOGPO_MONEDA, LOGPO_CODRESPUESTA, LOGPO_DATOS_PRODUCTO, LOGPO_CMCIOPOS_NOMBRE, LOGPO_IMPORTE_PEDIDO, LOGPO_NRO_PEDIDO, LOGPO_LOCAL_CODIGO, LOGPO_ESTADO_PEDIDO, LOGPO_TIPO_COMANDO, LOGPO_FORMA_PAGO, LOGPO_EST_PASARELA, LOGPO_NRO_TARJETA, LOGPO_FECHA_VENC, LOGPO_CODRETO_CMCIO, LOGPO_CODRETO_DESC, LOGPO_DATOSAPP1, LOGPO_DATOSAPP2, LOGPO_DATOSAPP3, LOGPO_DATOSAPP4, LOGPO_DATOSAPP5, LOGPO_ESTADO_CIERRE, LOGPO_COD_AUTORIZACION, LOGPO_ID_MOVIMIENTO, LOGPO_DATOSAPP6, LOGPO_DATOSAPP7, LOGPO_DATOSAPP8, LOGPO_DATOSAPP9, LOGPO_DATOSAPP10, LOGPO_ID_TRAN_ANULA, LOGPO_VISOR, LOGPO_VOUCHER, LOGPO_RESOLUTOR) NONRECOVERABLE INDEXING MODE AUTOSELECT;

LOAD FROM "D:\LPS_2006_2007.ixf" OF IXF METHOD P (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46)
MESSAGES "D:\LPS_2006_2007_Load.txt"
INSERT INTO SQMNUC.LOG_POS_SERV_HIST (LOGPO_IDSESION, LOGPO_CMCIO_ID, LOGPO_SERVI_CODIGO, LOGPO_FECHAYHORA, LOGPO_CANAL, LOGPO_ORIGEN, LOGPO_CMCIOPOS_CODIGO, LOGPO_CMCIO_CODIGO, LOGPO_CMCIO_CODGESTION, LOGPO_NRO_POS, LOGPO_ID_TRANSACCION, LOGPO_NRO_TRACE, LOGPO_TIPO_OPERACION, LOGPO_FECHAHORA_TRAN, LOGPO_MONEDA, LOGPO_CODRESPUESTA, LOGPO_DATOS_PRODUCTO, LOGPO_CMCIOPOS_NOMBRE, LOGPO_IMPORTE_PEDIDO, LOGPO_NRO_PEDIDO, LOGPO_LOCAL_CODIGO, LOGPO_ESTADO_PEDIDO, LOGPO_TIPO_COMANDO, LOGPO_FORMA_PAGO, LOGPO_EST_PASARELA, LOGPO_NRO_TARJETA, LOGPO_FECHA_VENC, LOGPO_CODRETO_CMCIO, LOGPO_CODRETO_DESC, LOGPO_DATOSAPP1, LOGPO_DATOSAPP2, LOGPO_DATOSAPP3, LOGPO_DATOSAPP4, LOGPO_DATOSAPP5, LOGPO_ESTADO_CIERRE, LOGPO_COD_AUTORIZACION, LOGPO_ID_MOVIMIENTO, LOGPO_DATOSAPP6, LOGPO_DATOSAPP7, LOGPO_DATOSAPP8, LOGPO_DATOSAPP9, LOGPO_DATOSAPP10, LOGPO_ID_TRAN_ANULA, LOGPO_VISOR, LOGPO_VOUCHER, LOGPO_RESOLUTOR) NONRECOVERABLE INDEXING MODE AUTOSELECT;

LOAD FROM "D:\LPS_2007_2008.ixf" OF IXF METHOD P (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46)
MESSAGES "D:\LPS_2007_2008_Load.txt"
INSERT INTO SQMNUC.LOG_POS_SERV_HIST (LOGPO_IDSESION, LOGPO_CMCIO_ID, LOGPO_SERVI_CODIGO, LOGPO_FECHAYHORA, LOGPO_CANAL, LOGPO_ORIGEN, LOGPO_CMCIOPOS_CODIGO, LOGPO_CMCIO_CODIGO, LOGPO_CMCIO_CODGESTION, LOGPO_NRO_POS, LOGPO_ID_TRANSACCION, LOGPO_NRO_TRACE, LOGPO_TIPO_OPERACION, LOGPO_FECHAHORA_TRAN, LOGPO_MONEDA, LOGPO_CODRESPUESTA, LOGPO_DATOS_PRODUCTO, LOGPO_CMCIOPOS_NOMBRE, LOGPO_IMPORTE_PEDIDO, LOGPO_NRO_PEDIDO, LOGPO_LOCAL_CODIGO, LOGPO_ESTADO_PEDIDO, LOGPO_TIPO_COMANDO, LOGPO_FORMA_PAGO, LOGPO_EST_PASARELA, LOGPO_NRO_TARJETA, LOGPO_FECHA_VENC, LOGPO_CODRETO_CMCIO, LOGPO_CODRETO_DESC, LOGPO_DATOSAPP1, LOGPO_DATOSAPP2, LOGPO_DATOSAPP3, LOGPO_DATOSAPP4, LOGPO_DATOSAPP5, LOGPO_ESTADO_CIERRE, LOGPO_COD_AUTORIZACION, LOGPO_ID_MOVIMIENTO, LOGPO_DATOSAPP6, LOGPO_DATOSAPP7, LOGPO_DATOSAPP8, LOGPO_DATOSAPP9, LOGPO_DATOSAPP10, LOGPO_ID_TRAN_ANULA, LOGPO_VISOR, LOGPO_VOUCHER, LOGPO_RESOLUTOR) NONRECOVERABLE INDEXING MODE AUTOSELECT;

LOAD FROM "D:\LPS_2008_2009.ixf" OF IXF METHOD P (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46)
MESSAGES "D:\LPS_2008_2009_Load.txt"
INSERT INTO SQMNUC.LOG_POS_SERV_HIST (LOGPO_IDSESION, LOGPO_CMCIO_ID, LOGPO_SERVI_CODIGO, LOGPO_FECHAYHORA, LOGPO_CANAL, LOGPO_ORIGEN, LOGPO_CMCIOPOS_CODIGO, LOGPO_CMCIO_CODIGO, LOGPO_CMCIO_CODGESTION, LOGPO_NRO_POS, LOGPO_ID_TRANSACCION, LOGPO_NRO_TRACE, LOGPO_TIPO_OPERACION, LOGPO_FECHAHORA_TRAN, LOGPO_MONEDA, LOGPO_CODRESPUESTA, LOGPO_DATOS_PRODUCTO, LOGPO_CMCIOPOS_NOMBRE, LOGPO_IMPORTE_PEDIDO, LOGPO_NRO_PEDIDO, LOGPO_LOCAL_CODIGO, LOGPO_ESTADO_PEDIDO, LOGPO_TIPO_COMANDO, LOGPO_FORMA_PAGO, LOGPO_EST_PASARELA, LOGPO_NRO_TARJETA, LOGPO_FECHA_VENC, LOGPO_CODRETO_CMCIO, LOGPO_CODRETO_DESC, LOGPO_DATOSAPP1, LOGPO_DATOSAPP2, LOGPO_DATOSAPP3, LOGPO_DATOSAPP4, LOGPO_DATOSAPP5, LOGPO_ESTADO_CIERRE, LOGPO_COD_AUTORIZACION, LOGPO_ID_MOVIMIENTO, LOGPO_DATOSAPP6, LOGPO_DATOSAPP7, LOGPO_DATOSAPP8, LOGPO_DATOSAPP9, LOGPO_DATOSAPP10, LOGPO_ID_TRAN_ANULA, LOGPO_VISOR, LOGPO_VOUCHER, LOGPO_RESOLUTOR) NONRECOVERABLE INDEXING MODE AUTOSELECT;

LOAD FROM "D:\LPS_2009_2010.ixf" OF IXF METHOD P (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46)
MESSAGES "D:\LPS_2009_2010_Load.txt"
INSERT INTO SQMNUC.LOG_POS_SERV_HIST (LOGPO_IDSESION, LOGPO_CMCIO_ID, LOGPO_SERVI_CODIGO, LOGPO_FECHAYHORA, LOGPO_CANAL, LOGPO_ORIGEN, LOGPO_CMCIOPOS_CODIGO, LOGPO_CMCIO_CODIGO, LOGPO_CMCIO_CODGESTION, LOGPO_NRO_POS, LOGPO_ID_TRANSACCION, LOGPO_NRO_TRACE, LOGPO_TIPO_OPERACION, LOGPO_FECHAHORA_TRAN, LOGPO_MONEDA, LOGPO_CODRESPUESTA, LOGPO_DATOS_PRODUCTO, LOGPO_CMCIOPOS_NOMBRE, LOGPO_IMPORTE_PEDIDO, LOGPO_NRO_PEDIDO, LOGPO_LOCAL_CODIGO, LOGPO_ESTADO_PEDIDO, LOGPO_TIPO_COMANDO, LOGPO_FORMA_PAGO, LOGPO_EST_PASARELA, LOGPO_NRO_TARJETA, LOGPO_FECHA_VENC, LOGPO_CODRETO_CMCIO, LOGPO_CODRETO_DESC, LOGPO_DATOSAPP1, LOGPO_DATOSAPP2, LOGPO_DATOSAPP3, LOGPO_DATOSAPP4, LOGPO_DATOSAPP5, LOGPO_ESTADO_CIERRE, LOGPO_COD_AUTORIZACION, LOGPO_ID_MOVIMIENTO, LOGPO_DATOSAPP6, LOGPO_DATOSAPP7, LOGPO_DATOSAPP8, LOGPO_DATOSAPP9, LOGPO_DATOSAPP10, LOGPO_ID_TRAN_ANULA, LOGPO_VISOR, LOGPO_VOUCHER, LOGPO_RESOLUTOR) NONRECOVERABLE INDEXING MODE AUTOSELECT;

LOAD FROM "D:\LPS_2010_2011.ixf" OF IXF METHOD P (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46)
MESSAGES "D:\LPS_2010_2011_Load.txt"
INSERT INTO SQMNUC.LOG_POS_SERV_HIST (LOGPO_IDSESION, LOGPO_CMCIO_ID, LOGPO_SERVI_CODIGO, LOGPO_FECHAYHORA, LOGPO_CANAL, LOGPO_ORIGEN, LOGPO_CMCIOPOS_CODIGO, LOGPO_CMCIO_CODIGO, LOGPO_CMCIO_CODGESTION, LOGPO_NRO_POS, LOGPO_ID_TRANSACCION, LOGPO_NRO_TRACE, LOGPO_TIPO_OPERACION, LOGPO_FECHAHORA_TRAN, LOGPO_MONEDA, LOGPO_CODRESPUESTA, LOGPO_DATOS_PRODUCTO, LOGPO_CMCIOPOS_NOMBRE, LOGPO_IMPORTE_PEDIDO, LOGPO_NRO_PEDIDO, LOGPO_LOCAL_CODIGO, LOGPO_ESTADO_PEDIDO, LOGPO_TIPO_COMANDO, LOGPO_FORMA_PAGO, LOGPO_EST_PASARELA, LOGPO_NRO_TARJETA, LOGPO_FECHA_VENC, LOGPO_CODRETO_CMCIO, LOGPO_CODRETO_DESC, LOGPO_DATOSAPP1, LOGPO_DATOSAPP2, LOGPO_DATOSAPP3, LOGPO_DATOSAPP4, LOGPO_DATOSAPP5, LOGPO_ESTADO_CIERRE, LOGPO_COD_AUTORIZACION, LOGPO_ID_MOVIMIENTO, LOGPO_DATOSAPP6, LOGPO_DATOSAPP7, LOGPO_DATOSAPP8, LOGPO_DATOSAPP9, LOGPO_DATOSAPP10, LOGPO_ID_TRAN_ANULA, LOGPO_VISOR, LOGPO_VOUCHER, LOGPO_RESOLUTOR) NONRECOVERABLE INDEXING MODE AUTOSELECT;

LOAD FROM "D:\LPS_2011_2012.ixf" OF IXF METHOD P (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46)
MESSAGES "D:\LPS_2011_2012_Load.txt"
INSERT INTO SQMNUC.LOG_POS_SERV_HIST (LOGPO_IDSESION, LOGPO_CMCIO_ID, LOGPO_SERVI_CODIGO, LOGPO_FECHAYHORA, LOGPO_CANAL, LOGPO_ORIGEN, LOGPO_CMCIOPOS_CODIGO, LOGPO_CMCIO_CODIGO, LOGPO_CMCIO_CODGESTION, LOGPO_NRO_POS, LOGPO_ID_TRANSACCION, LOGPO_NRO_TRACE, LOGPO_TIPO_OPERACION, LOGPO_FECHAHORA_TRAN, LOGPO_MONEDA, LOGPO_CODRESPUESTA, LOGPO_DATOS_PRODUCTO, LOGPO_CMCIOPOS_NOMBRE, LOGPO_IMPORTE_PEDIDO, LOGPO_NRO_PEDIDO, LOGPO_LOCAL_CODIGO, LOGPO_ESTADO_PEDIDO, LOGPO_TIPO_COMANDO, LOGPO_FORMA_PAGO, LOGPO_EST_PASARELA, LOGPO_NRO_TARJETA, LOGPO_FECHA_VENC, LOGPO_CODRETO_CMCIO, LOGPO_CODRETO_DESC, LOGPO_DATOSAPP1, LOGPO_DATOSAPP2, LOGPO_DATOSAPP3, LOGPO_DATOSAPP4, LOGPO_DATOSAPP5, LOGPO_ESTADO_CIERRE, LOGPO_COD_AUTORIZACION, LOGPO_ID_MOVIMIENTO, LOGPO_DATOSAPP6, LOGPO_DATOSAPP7, LOGPO_DATOSAPP8, LOGPO_DATOSAPP9, LOGPO_DATOSAPP10, LOGPO_ID_TRAN_ANULA, LOGPO_VISOR, LOGPO_VOUCHER, LOGPO_RESOLUTOR) NONRECOVERABLE INDEXING MODE AUTOSELECT;

LOAD FROM "D:\LPS_2012_2013.ixf" OF IXF METHOD P (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46)
MESSAGES "D:\LPS_2012_2013_Load.txt"
INSERT INTO SQMNUC.LOG_POS_SERV_HIST (LOGPO_IDSESION, LOGPO_CMCIO_ID, LOGPO_SERVI_CODIGO, LOGPO_FECHAYHORA, LOGPO_CANAL, LOGPO_ORIGEN, LOGPO_CMCIOPOS_CODIGO, LOGPO_CMCIO_CODIGO, LOGPO_CMCIO_CODGESTION, LOGPO_NRO_POS, LOGPO_ID_TRANSACCION, LOGPO_NRO_TRACE, LOGPO_TIPO_OPERACION, LOGPO_FECHAHORA_TRAN, LOGPO_MONEDA, LOGPO_CODRESPUESTA, LOGPO_DATOS_PRODUCTO, LOGPO_CMCIOPOS_NOMBRE, LOGPO_IMPORTE_PEDIDO, LOGPO_NRO_PEDIDO, LOGPO_LOCAL_CODIGO, LOGPO_ESTADO_PEDIDO, LOGPO_TIPO_COMANDO, LOGPO_FORMA_PAGO, LOGPO_EST_PASARELA, LOGPO_NRO_TARJETA, LOGPO_FECHA_VENC, LOGPO_CODRETO_CMCIO, LOGPO_CODRETO_DESC, LOGPO_DATOSAPP1, LOGPO_DATOSAPP2, LOGPO_DATOSAPP3, LOGPO_DATOSAPP4, LOGPO_DATOSAPP5, LOGPO_ESTADO_CIERRE, LOGPO_COD_AUTORIZACION, LOGPO_ID_MOVIMIENTO, LOGPO_DATOSAPP6, LOGPO_DATOSAPP7, LOGPO_DATOSAPP8, LOGPO_DATOSAPP9, LOGPO_DATOSAPP10, LOGPO_ID_TRAN_ANULA, LOGPO_VISOR, LOGPO_VOUCHER, LOGPO_RESOLUTOR) NONRECOVERABLE INDEXING MODE AUTOSELECT;

LOAD FROM "D:\LPS_2013_2014.ixf" OF IXF METHOD P (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46)
MESSAGES "D:\LPS_2013_2014_Load.txt"
INSERT INTO SQMNUC.LOG_POS_SERV_HIST (LOGPO_IDSESION, LOGPO_CMCIO_ID, LOGPO_SERVI_CODIGO, LOGPO_FECHAYHORA, LOGPO_CANAL, LOGPO_ORIGEN, LOGPO_CMCIOPOS_CODIGO, LOGPO_CMCIO_CODIGO, LOGPO_CMCIO_CODGESTION, LOGPO_NRO_POS, LOGPO_ID_TRANSACCION, LOGPO_NRO_TRACE, LOGPO_TIPO_OPERACION, LOGPO_FECHAHORA_TRAN, LOGPO_MONEDA, LOGPO_CODRESPUESTA, LOGPO_DATOS_PRODUCTO, LOGPO_CMCIOPOS_NOMBRE, LOGPO_IMPORTE_PEDIDO, LOGPO_NRO_PEDIDO, LOGPO_LOCAL_CODIGO, LOGPO_ESTADO_PEDIDO, LOGPO_TIPO_COMANDO, LOGPO_FORMA_PAGO, LOGPO_EST_PASARELA, LOGPO_NRO_TARJETA, LOGPO_FECHA_VENC, LOGPO_CODRETO_CMCIO, LOGPO_CODRETO_DESC, LOGPO_DATOSAPP1, LOGPO_DATOSAPP2, LOGPO_DATOSAPP3, LOGPO_DATOSAPP4, LOGPO_DATOSAPP5, LOGPO_ESTADO_CIERRE, LOGPO_COD_AUTORIZACION, LOGPO_ID_MOVIMIENTO, LOGPO_DATOSAPP6, LOGPO_DATOSAPP7, LOGPO_DATOSAPP8, LOGPO_DATOSAPP9, LOGPO_DATOSAPP10, LOGPO_ID_TRAN_ANULA, LOGPO_VISOR, LOGPO_VOUCHER, LOGPO_RESOLUTOR) NONRECOVERABLE INDEXING MODE AUTOSELECT;

LOAD FROM "D:\LPS_2014_2015.ixf" OF IXF METHOD P (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46)
MESSAGES "D:\LPS_2014_2015_Load.txt"
INSERT INTO SQMNUC.LOG_POS_SERV_HIST (LOGPO_IDSESION, LOGPO_CMCIO_ID, LOGPO_SERVI_CODIGO, LOGPO_FECHAYHORA, LOGPO_CANAL, LOGPO_ORIGEN, LOGPO_CMCIOPOS_CODIGO, LOGPO_CMCIO_CODIGO, LOGPO_CMCIO_CODGESTION, LOGPO_NRO_POS, LOGPO_ID_TRANSACCION, LOGPO_NRO_TRACE, LOGPO_TIPO_OPERACION, LOGPO_FECHAHORA_TRAN, LOGPO_MONEDA, LOGPO_CODRESPUESTA, LOGPO_DATOS_PRODUCTO, LOGPO_CMCIOPOS_NOMBRE, LOGPO_IMPORTE_PEDIDO, LOGPO_NRO_PEDIDO, LOGPO_LOCAL_CODIGO, LOGPO_ESTADO_PEDIDO, LOGPO_TIPO_COMANDO, LOGPO_FORMA_PAGO, LOGPO_EST_PASARELA, LOGPO_NRO_TARJETA, LOGPO_FECHA_VENC, LOGPO_CODRETO_CMCIO, LOGPO_CODRETO_DESC, LOGPO_DATOSAPP1, LOGPO_DATOSAPP2, LOGPO_DATOSAPP3, LOGPO_DATOSAPP4, LOGPO_DATOSAPP5, LOGPO_ESTADO_CIERRE, LOGPO_COD_AUTORIZACION, LOGPO_ID_MOVIMIENTO, LOGPO_DATOSAPP6, LOGPO_DATOSAPP7, LOGPO_DATOSAPP8, LOGPO_DATOSAPP9, LOGPO_DATOSAPP10, LOGPO_ID_TRAN_ANULA, LOGPO_VISOR, LOGPO_VOUCHER, LOGPO_RESOLUTOR) NONRECOVERABLE INDEXING MODE AUTOSELECT;

COMMIT WORK;