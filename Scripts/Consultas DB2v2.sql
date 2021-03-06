CONNECT TO DB3DSNUC USER db2admin USING db2admin;

--deshacer los cambios
DROP TABLE SQMNUC.GRUPO_USUARIO_COMERCIO;
DROP TABLE SQMNUC.USUARIO_COMERCIO_CONS;
DROP TABLE SQMNUC.COMERCIO_CONSULTA;
DROP TABLE SQMNUC.GRUPO_COMERCIO;
DROP TABLE SQMNUC.SERVICIO_CONSULTA;
DROP TABLE SQMNUC.SERVICIOXEMPRESA;
DROP TABLE SQMNUC.ANALISIS;

CREATE TABLE SQMNUC.ANALISIS
( FECHAINSERT TIMESTAMP NOT NULL,
DATA VARCHAR(200) ) ;



--CREACION DE LA TABLA DE GRUPOS DE COMERCIO
CREATE TABLE SQMNUC.GRUPO_COMERCIO
( IDGRUPO INTEGER NOT NULL  GENERATED ALWAYS AS IDENTITY (START WITH 1, INCREMENT BY 1, NO CACHE ) ,
CMCIO_ID INTEGER NOT NULL ,
COD_GRUPO VARCHAR (11)  NOT NULL ,
NOMBRE_GRUPO VARCHAR(50)  NULL  WITH DEFAULT ''  ,
FLAG_RUC INTEGER NOT NULL  WITH DEFAULT 0  ,
RUC DECIMAL(15) NULL  WITH DEFAULT 0  ,
DESC_GRUPO VARCHAR(100)  NULL  WITH DEFAULT ''  ,
FECHAINSERT TIMESTAMP NOT NULL,
FECHAULTACTUALIZ TIMESTAMP NOT NULL,
CONSTRAINT PK_GRUPO_COMERCIO PRIMARY KEY ( IDGRUPO)  ) ;

COMMENT ON TABLE SQMNUC.GRUPO_COMERCIO IS 'Grupo de comercios para consulta';
COMMENT ON SQMNUC.GRUPO_COMERCIO ( IDGRUPO IS 'id autogenerado' ) ;

--CREACION DE LA TABLA DE COMERCIOS
CREATE TABLE SQMNUC.COMERCIO_CONSULTA
( IDGRUPO INTEGER  NOT NULL ,
CODCOMERCIO CHARACTER (9)  NOT NULL  ,
FECHAINSERT TIMESTAMP NOT NULL,
FECHAULTACTUALIZ TIMESTAMP NOT NULL,
CONSTRAINT PK_COMERCIO_CONSULTA PRIMARY KEY ( IDGRUPO, CODCOMERCIO) ,
CONSTRAINT FK_GRUPO_COMERCIO_CONS FOREIGN KEY (IDGRUPO) REFERENCES SQMNUC.GRUPO_COMERCIO (IDGRUPO)  ON DELETE CASCADE ON UPDATE NO ACTION ENFORCED
ENABLE QUERY OPTIMIZATION  ) ;

--CREACION DE LA TABLA DE USUARIOS
CREATE TABLE SQMNUC.USUARIO_COMERCIO_CONS
( IDUSUARIO INTEGER  NOT NULL  GENERATED ALWAYS AS IDENTITY (START WITH 1, INCREMENT BY 1, NO CACHE ) ,
FLAGADMIN INTEGER  NOT NULL ,
IDGRUPO INTEGER  NOT NULL ,
LOGIN VARCHAR (20)  NOT NULL ,
PASSWORD VARCHAR (20)  NOT NULL  ,
NOMBRE VARCHAR (30)  NULL  ,
APELLIDOP VARCHAR (30)  NULL  ,
EMAIL VARCHAR (50)  NULL  ,
ESTADO CHAR (1)  NULL  ,
FECHAINSERT TIMESTAMP NOT NULL,
FECHAULTACTUALIZ TIMESTAMP NOT NULL,
CONSTRAINT PK_USUARIO_GRUPO_CONS PRIMARY KEY ( IDUSUARIO),
CONSTRAINT FK_USUARIO_GRUPO FOREIGN KEY (IDGRUPO) REFERENCES SQMNUC.GRUPO_COMERCIO (IDGRUPO)    ) ;

--CREACION DE LA TABLA DE SERVICIOS
CREATE TABLE SQMNUC.SERVICIO_CONSULTA (
IDGRUPO INTEGER  NOT NULL ,
SERVI_CODIGO INTEGER  NOT NULL  ,
FECHAINSERT TIMESTAMP NOT NULL,
FECHAULTACTUALIZ TIMESTAMP NOT NULL,
CONSTRAINT PK_SERVICIO_CONSULTA PRIMARY KEY ( IDGRUPO, SERVI_CODIGO) ,
CONSTRAINT FK_SERVICIO_CONSULTA FOREIGN KEY (IDGRUPO) REFERENCES SQMNUC.GRUPO_COMERCIO (IDGRUPO)  ON DELETE CASCADE ON UPDATE NO ACTION ENFORCED  ENABLE QUERY OPTIMIZATION  ) ;

--CREACION DE LA TABLA DE SERVICIOS POR EMPRESA
CREATE TABLE SQMNUC.SERVICIOXEMPRESA (
CMCIO_ID INTEGER  NOT NULL ,
SERVI_CODIGO INTEGER  NOT NULL  ,
FECHAINSERT TIMESTAMP NOT NULL,
FECHAULTACTUALIZ TIMESTAMP NOT NULL,
CONSTRAINT PK_SERVICIOXEMPRESA PRIMARY KEY ( CMCIO_ID, SERVI_CODIGO));

DELETE FROM SQMNUC.SERVICIOXEMPRESA;
INSERT INTO SQMNUC.SERVICIOXEMPRESA(CMCIO_ID, SERVI_CODIGO, FECHAINSERT, FECHAULTACTUALIZ)
VALUES(37, 108, CURRENT TIMESTAMP, CURRENT TIMESTAMP);
INSERT INTO SQMNUC.SERVICIOXEMPRESA(CMCIO_ID, SERVI_CODIGO, FECHAINSERT, FECHAULTACTUALIZ)
VALUES(37, 109, CURRENT TIMESTAMP, CURRENT TIMESTAMP);
INSERT INTO SQMNUC.SERVICIOXEMPRESA(CMCIO_ID, SERVI_CODIGO, FECHAINSERT, FECHAULTACTUALIZ)
VALUES(37, 110, CURRENT TIMESTAMP, CURRENT TIMESTAMP);


--INSERT DE PRUEBA
INSERT INTO SQMNUC.GRUPO_COMERCIO(COD_GRUPO, FLAG_RUC, NOMBRE_GRUPO, RUC, FECHAINSERT, FECHAULTACTUALIZ)
VALUES ('20341198217', 0, 'GRUPO PRUEBA VISANET', 0, CURRENT TIMESTAMP, CURRENT TIMESTAMP);

INSERT INTO SQMNUC.COMERCIO_CONSULTA(IDGRUPO, CODCOMERCIO, FECHAINSERT, FECHAULTACTUALIZ)
VALUES (1, '341198207', CURRENT TIMESTAMP, CURRENT TIMESTAMP);
INSERT INTO SQMNUC.COMERCIO_CONSULTA(IDGRUPO, CODCOMERCIO, FECHAINSERT, FECHAULTACTUALIZ)
VALUES (1, '999666333', CURRENT TIMESTAMP, CURRENT TIMESTAMP);
INSERT INTO SQMNUC.COMERCIO_CONSULTA(IDGRUPO, CODCOMERCIO, FECHAINSERT, FECHAULTACTUALIZ)
VALUES (1, '000000001', CURRENT TIMESTAMP, CURRENT TIMESTAMP);
INSERT INTO SQMNUC.COMERCIO_CONSULTA(IDGRUPO, CODCOMERCIO, FECHAINSERT, FECHAULTACTUALIZ)
VALUES (1, '100014302', CURRENT TIMESTAMP, CURRENT TIMESTAMP);


INSERT INTO SQMNUC.USUARIO_COMERCIO_CONS(LOGIN, PASSWORD, NOMBRE, APELLIDOP, EMAIL, FLAGADMIN, IDGRUPO, ESTADO, FECHAINSERT, FECHAULTACTUALIZ)
VALUES ('USRPRUEBA', 'USRPRUEBA', 'JOSE', 'VILLAVICENCIO', 'pepevillavicencio@gmail.com', 0, 1, 'A', CURRENT TIMESTAMP, CURRENT TIMESTAMP);
INSERT INTO SQMNUC.USUARIO_COMERCIO_CONS(LOGIN, PASSWORD, NOMBRE, APELLIDOP, EMAIL, FLAGADMIN, IDGRUPO, ESTADO, FECHAINSERT, FECHAULTACTUALIZ)
VALUES ('USRPRUEBA2', 'USRPRUEBA2', 'JUAN', 'PEREZ', 'pepevillavicencio@gmail.com', 0, 1, 'A', CURRENT TIMESTAMP, CURRENT TIMESTAMP);



INSERT INTO SQMNUC.SERVICIO_CONSULTA(IDGRUPO, SERVI_CODIGO, FECHAINSERT, FECHAULTACTUALIZ)
VALUES (1, 225, CURRENT TIMESTAMP, CURRENT TIMESTAMP);
INSERT INTO SQMNUC.SERVICIO_CONSULTA(IDGRUPO, SERVI_CODIGO, FECHAINSERT, FECHAULTACTUALIZ)
VALUES (1, 226, CURRENT TIMESTAMP, CURRENT TIMESTAMP);
INSERT INTO SQMNUC.SERVICIO_CONSULTA(IDGRUPO, SERVI_CODIGO, FECHAINSERT, FECHAULTACTUALIZ)
VALUES (1, 360, CURRENT TIMESTAMP, CURRENT TIMESTAMP);
INSERT INTO SQMNUC.SERVICIO_CONSULTA(IDGRUPO, SERVI_CODIGO, FECHAINSERT, FECHAULTACTUALIZ)
VALUES (1, 361, CURRENT TIMESTAMP, CURRENT TIMESTAMP);



*********************************************

--CREACION DE LA TABLA DE GRUPOS POR USUARIO
CREATE TABLE SQMNUC.GRUPO_USUARIO_COMERCIO_CONS
( IDGRUPO INTEGER  NOT NULL ,
IDUSUARIO INTEGER  NOT NULL  ,
FECHAINSERT TIMESTAMP NOT NULL,
FECHAULTACTUALIZ TIMESTAMP NOT NULL,
CONSTRAINT PK_GRUPO_USUARIO_CONS PRIMARY KEY ( IDGRUPO, IDUSUARIO) ,
CONSTRAINT FK_GRU_CONSULTA FOREIGN KEY (IDGRUPO) REFERENCES SQMNUC.GRUPO_COMERCIO (IDGRUPO)
ON DELETE CASCADE ON UPDATE NO ACTION ENFORCED  ENABLE QUERY OPTIMIZATION ,
CONSTRAINT FK_USU_CONSULTA FOREIGN KEY (IDUSUARIO) REFERENCES SQMNUC.USUARIO_COMERCIO_CONS (IDUSUARIO)
ON DELETE CASCADE ON UPDATE NO ACTION ENFORCED  ENABLE QUERY OPTIMIZATION  ) ;

INSERT INTO SQMNUC.GRUPO_USUARIO_COMERCIO_CONS(IDGRUPO, IDUSUARIO, FECHAINSERT, FECHAULTACTUALIZ)
VALUES (1, 1, CURRENT TIMESTAMP, CURRENT TIMESTAMP);
