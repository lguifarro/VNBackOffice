CONNECT TO DB3DSNUC USER db2admin USING db2admin;

ALTER TABLE SQMNUC.SERVICIO ADD COLUMN SERVI_ESTADO INTEGER  WITH DEFAULT 0 ;
UPDATE SQMNUC.SERVICIO SET SERVI_ESTADO = 1
WHERE SERVI_CODIGO IN (108, 109, 110, 111, 113, 115, 116, 117, 118, 119, 165, 170, 171, 172, 173, 201, 202, 203, 204, 205, 206, 207, 208, 209, 215, 216, 217, 218, 225, 226, 227, 265, 266, 267, 268, 280, 281, 282, 285, 286, 287, 288, 290, 291, 292, 293, 204, 301, 302, 303, 304, 320, 322, 325, 326, 327, 328, 329, 354, 360, 361, 362, 365, 366, 367, 368, 385, 386, 387, 388, 410, 411, 412, 420, 421, 422);


--CAMBIAR ESTADO DE LA TABLA DE COMERCIOS
UPDATE SQMNUC.COMERCIO SET CMCIO_ESTADO = LEFT(CMCIO_ESTADO, 1);
CALL SYSPROC.ALTOBJ ( 'APPLY_CONTINUE_ON_ERROR', 'CREATE TABLE SQMNUC.COMERCIO ( CMCIO_CODIGO VARCHAR (15)  NOT NULL , CMCIO_NOMBRE VARCHAR (50)  NOT NULL , CMCIO_RAZONSOCIAL VARCHAR (50) , CMCIO_RUC VARCHAR (11)  NOT NULL , CMCIO_DIR_ADM VARCHAR (50) , CMCIO_TEL_ADM VARCHAR (12) , CMCIO_DIR_COM VARCHAR (50) , CMCIO_TEL_COM VARCHAR (12) , CMCIO_FUNCIONARIO VARCHAR (50) , MNDA_CODIGO VARCHAR (3) , CMCIO_ESTADO CHARACTER (1)  NOT NULL , CMCIO_FEC_ALTA DATE , GIRNE_MCC_INT INTEGER , CMCIO_FAX_COM VARCHAR (12) , CMCIO_FAX_ADM VARCHAR (12) , CMCIO_CODGESTION VARCHAR (9)  NOT NULL , SERVI_CODIGO SMALLINT  NOT NULL , CMCIO_MSGVOZNOMBRE VARCHAR (50) , CMCIO_CODACCESO VARCHAR (4) , CMCIO_ORDENMENU VARCHAR (1) , CMCIO_ID INTEGER  NOT NULL , UBIGE_DPTO_ADM CHARACTER (2) , UBIGE_DIST_ADM CHARACTER (2) , UBIGE_PROV_ADM CHARACTER (2) , UBIGE_DIST_COM CHARACTER (2) , UBIGE_PROV_COM CHARACTER (2) , UBIGE_DPTO_COM CHARACTER (2) , VIA_COD_ADM CHARACTER (2) , VIA_COD_COM CHARACTER (2) , COPTAL_COD_ADM CHARACTER (4) , COPTAL_COD_COM CHARACTER (4)   ) IN USERSPACE1 ', -1, ? );


UPDATE SQMNUC.COMERCIO
SET CMCIO_ESTADO = 'I'
WHERE CMCIO_ID IN (1, 4, 5, 6, 8, 9, 10, 11, 13, 14, 15, 16, 17, 18, 20, 21, 22, 24, 25, 26, 27, 28, 34, 44, 46, 50, 61, 66);



--deshacer los cambios
DROP TABLE SQMNUC.USUARIO_ADMIN;



--CREACION DE LA TABLA DE USUARIOS
CREATE TABLE SQMNUC.USUARIO_ADMIN
( IDUSUARIO INTEGER  NOT NULL  GENERATED ALWAYS AS IDENTITY (START WITH 1, INCREMENT BY 1, NO CACHE ) ,
NIVEL INTEGER  NOT NULL ,
LOGIN VARCHAR (20)  NOT NULL ,
PASSWORD VARCHAR (20)  NOT NULL  ,
NOMBRE VARCHAR (50)  NULL  ,
APELLIDOP VARCHAR (50)  NULL  ,
EMAIL VARCHAR (50)  NULL  ,
ESTADO CHAR (1)  NULL WITH DEFAULT 'A' ,
FECHAINSERT TIMESTAMP NOT NULL,
FECHAULTACTUALIZ TIMESTAMP NOT NULL,
CONSTRAINT PK_USUARIO_ADMIN PRIMARY KEY ( IDUSUARIO)  ) ;


--INSERT DE PRUEBA
INSERT INTO SQMNUC.USUARIO_ADMIN(NIVEL, LOGIN, PASSWORD, NOMBRE, APELLIDOP, EMAIL, ESTADO, FECHAINSERT, FECHAULTACTUALIZ)
VALUES (1, 'USRPRUEBA', 'USRPRUEBA', 'JOSE', 'VILLAVICENCIO', 'pepevillavicencio@gmail.com', 'A', CURRENT TIMESTAMP, CURRENT TIMESTAMP);


--CREACION DE LA TABLA DE TARIFAS
DROP TABLE SQMNUC.TARIFA_TRX;
DROP TABLE SQMNUC.PLAN_TARIFARIO;

CREATE TABLE SQMNUC.PLAN_TARIFARIO
(
CMCIO_ID INTEGER  NOT NULL ,
TIPO_CALCULO VARCHAR(1)  NOT NULL ,
MONEDA VARCHAR (1)  NOT NULL  ,
FECHAINSERT TIMESTAMP NOT NULL,
FECHAULTACTUALIZ TIMESTAMP NOT NULL,
CONSTRAINT PK_PLAN_TARIFARIO PRIMARY KEY (CMCIO_ID) ) ;

CREATE TABLE SQMNUC.TARIFA_TRX
(IDTARIFA INTEGER  NOT NULL  GENERATED ALWAYS AS IDENTITY (START WITH 1, INCREMENT BY 1, NO CACHE ) ,
CMCIO_ID INTEGER  NOT NULL ,
TRX_DESDE BIGINT  NOT NULL ,
TRX_HASTA BIGINT  NOT NULL ,
TARIFA DOUBLE  NOT NULL ,
FECHAINSERT TIMESTAMP NOT NULL,
FECHAULTACTUALIZ TIMESTAMP NOT NULL,
CONSTRAINT PK_TARIFA_TRX PRIMARY KEY (IDTARIFA)  ) ;
