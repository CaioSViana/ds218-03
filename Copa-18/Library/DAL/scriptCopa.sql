use master

go
drop database COPA_18

go
create database COPA_18

go
use COPA_18

go
create table TB_ESTADIO(
	ID_ESTADIO INT IDENTITY(1,1) CONSTRAINT PK_TB_ESTADIO PRIMARY KEY,
	DS_ESTADIO VARCHAR (100) NOT NULL,
	DS_CIDADE VARCHAR (100) NOT NULL,
	DS_CAPACIDADE INT NOT NULL,
	DS_IMAGEM_ESTADIO  varbinary(MAX),
	DS_TIPO_IMAGEM_ESTADIO VARCHAR(50),
	DS_CAMINHO_IMAGEM_ESTADIO VARCHAR(MAX),
)

GO
create table TB_GRUPO(
	ID_GRUPO INT IDENTITY(1,1) CONSTRAINT PK_TB_GRUPO PRIMARY KEY,
	DS_GRUPO CHAR NOT NULL
)

GO
create table TB_SELECAO(
	ID_SELECAO INT IDENTITY(1,1) CONSTRAINT PK_TB_SELECAO PRIMARY KEY,
	DS_SELECAO VARCHAR (100) NOT NULL,
	ID_GRUPO_SELECAO INT NOT NULL CONSTRAINT FK_TB_SELECAO_TB_GRUPO FOREIGN KEY REFERENCES TB_GRUPO(ID_GRUPO),
	DS_IMAGEM_BANDEIRA varbinary(MAX),
	DS_TIPO_IMAGEM_BANDEIRA VARCHAR(50),
	DS_CAMINHO_IMAGEM_BANDEIRA VARCHAR(MAX)
)


GO
create table TB_POSICAO(
	ID_POSICAO INT IDENTITY(1,1) CONSTRAINT PK_TB_POSICAO PRIMARY KEY,
	DS_POSICAO VARCHAR (100) NOT NULL	
)

GO
CREATE TABLE TB_JOGADOR(
	ID_JOGADOR INT IDENTITY(1,1) CONSTRAINT PK_TB_JOGADOR PRIMARY KEY,
	DS_NOME VARCHAR (100) NOT NULL,
	NR_NUMERO INT NOT NULL,
	ID_POSICAO_JOGADOR INT NOT NULL CONSTRAINT FK_TB_SELECAO_TB_POSICAO FOREIGN KEY REFERENCES TB_POSICAO(ID_POSICAO),
	ID_SELECAO_JOGADOR INT NOT NULL CONSTRAINT FK_TB_SELECAO_TB_SELECAO FOREIGN KEY REFERENCES TB_SELECAO(ID_SELECAO),
	DS_IMAGEM_JOGADOR varbinary(MAX),
	DS_TIPO_IMAGEM_JOGADOR VARCHAR(50),
	DS_CAMINHO_IMAGEM_JOGADOR VARCHAR(MAX)
)

GO
CREATE TABLE TB_FASE(
	ID_FASE INT IDENTITY(1,1) CONSTRAINT PK_FASE PRIMARY KEY,
	DS_FASE VARCHAR(50)
)

GO
CREATE TABLE TB_PARTIDA(
	ID_PARTIDA INT IDENTITY(1,1) CONSTRAINT PK_TB_PARTIDA PRIMARY KEY,
	DT_PARTIDA DATETIME NOT NULL,
	DS_PARTIDA VARCHAR (150),
	ID_FASE_PARTIDA INT NOT NULL CONSTRAINT FK_TB_PARTIDA_TB_FASE FOREIGN KEY REFERENCES TB_FASE(ID_FASE),	
	ID_ESTADIO_PARTIDA INT NOT NULL CONSTRAINT FK_TB_PARTIDA_TB_ESTADIO FOREIGN KEY REFERENCES TB_ESTADIO(ID_ESTADIO)	
)

GO
CREATE TABLE TB_PLACAR(
	ID_PLACAR INT IDENTITY(1,1) CONSTRAINT PK_TB_PLACAR PRIMARY KEY,
	ID_PARTIDA_PLACAR INT NOT NULL CONSTRAINT FK_TB_PLACAR_TB_PARTIDA FOREIGN KEY REFERENCES TB_PARTIDA(ID_PARTIDA),		
	ID_SELECAO INT NOT NULL CONSTRAINT FK_TB_PLACAR_TB_SELECAO FOREIGN KEY REFERENCES TB_SELECAO(ID_SELECAO),	
	BL_MANDANTE BIT NOT NULL,
	NR_GOL INT NOT NULL,
	NR_GOL_PRORROGACAO INT,
	NR_GOL_DECISAO_PENALTIS INT	
)

INSERT INTO TB_ESTADIO (DS_ESTADIO, DS_CIDADE,  DS_CAPACIDADE) VALUES ('Est�dio Lujniki', 'Moscou', 81000)
INSERT INTO TB_ESTADIO (DS_ESTADIO, DS_CIDADE,  DS_CAPACIDADE) VALUES ('Arena Otkrytie (Est�dio Spartak)', 'Moscou', 45360)
INSERT INTO TB_ESTADIO (DS_ESTADIO, DS_CIDADE,  DS_CAPACIDADE) VALUES ('Est�dio Krestovsk (Est�dio de S�o Petersburgo)', 'S�o Petersburgo', 68134)
INSERT INTO TB_ESTADIO (DS_ESTADIO, DS_CIDADE,  DS_CAPACIDADE) VALUES ('Est�dio de Kaliningrado', 'Kaliningrado', 35212)
INSERT INTO TB_ESTADIO (DS_ESTADIO, DS_CIDADE,  DS_CAPACIDADE) VALUES ('Arena Kazan', 'Kazan', 45105)
INSERT INTO TB_ESTADIO (DS_ESTADIO, DS_CIDADE,  DS_CAPACIDADE) VALUES ('Est�dio de N�jni Novgorod', 'N�jni Novgorod', 44899)
INSERT INTO TB_ESTADIO (DS_ESTADIO, DS_CIDADE,  DS_CAPACIDADE) VALUES ('Est�dio de Samara', 'Samara', 44918)
INSERT INTO TB_ESTADIO (DS_ESTADIO, DS_CIDADE,  DS_CAPACIDADE) VALUES ('Arena Volgogrado', 'Volgogrado', 44015)
INSERT INTO TB_ESTADIO (DS_ESTADIO, DS_CIDADE,  DS_CAPACIDADE) VALUES ('Arena Mordovia', 'Saransk', 45015)
INSERT INTO TB_ESTADIO (DS_ESTADIO, DS_CIDADE,  DS_CAPACIDADE) VALUES ('Arena Rostov', 'Rostov do Don', 43702)
INSERT INTO TB_ESTADIO (DS_ESTADIO, DS_CIDADE,  DS_CAPACIDADE) VALUES ('Est�dio Ol�mpico de Fisht', 'S�chi', 47659)
INSERT INTO TB_ESTADIO (DS_ESTADIO, DS_CIDADE,  DS_CAPACIDADE) VALUES ('Est�dio Central', 'Ecaterimburgo', 44130)

INSERT INTO TB_GRUPO VALUES ('A')
INSERT INTO TB_GRUPO VALUES ('B')
INSERT INTO TB_GRUPO VALUES ('C')
INSERT INTO TB_GRUPO VALUES ('D')
INSERT INTO TB_GRUPO VALUES ('E')
INSERT INTO TB_GRUPO VALUES ('F')
INSERT INTO TB_GRUPO VALUES ('G')
INSERT INTO TB_GRUPO VALUES ('H')

INSERT INTO TB_SELECAO(DS_SELECAO, ID_GRUPO_SELECAO) VALUES ('R�ssia',1)
INSERT INTO TB_SELECAO(DS_SELECAO, ID_GRUPO_SELECAO) VALUES ('Ar�bia Saudita',1)
INSERT INTO TB_SELECAO(DS_SELECAO, ID_GRUPO_SELECAO) VALUES ('Egito',1)
INSERT INTO TB_SELECAO(DS_SELECAO, ID_GRUPO_SELECAO) VALUES ('Uruguai',1)

INSERT INTO TB_SELECAO(DS_SELECAO, ID_GRUPO_SELECAO) VALUES ('Portugal',2)
INSERT INTO TB_SELECAO(DS_SELECAO, ID_GRUPO_SELECAO) VALUES ('Espanha',2)
INSERT INTO TB_SELECAO(DS_SELECAO, ID_GRUPO_SELECAO) VALUES ('Marrocos',2)
INSERT INTO TB_SELECAO(DS_SELECAO, ID_GRUPO_SELECAO) VALUES ('Ir�',2)

INSERT INTO TB_SELECAO(DS_SELECAO, ID_GRUPO_SELECAO) VALUES ('Fran�a',3)
INSERT INTO TB_SELECAO(DS_SELECAO, ID_GRUPO_SELECAO) VALUES ('Austr�lia',3)
INSERT INTO TB_SELECAO(DS_SELECAO, ID_GRUPO_SELECAO) VALUES ('Peru',3)
INSERT INTO TB_SELECAO(DS_SELECAO, ID_GRUPO_SELECAO) VALUES ('Dinamarca',3)

INSERT INTO TB_SELECAO(DS_SELECAO, ID_GRUPO_SELECAO) VALUES ('Argentina',4)
INSERT INTO TB_SELECAO(DS_SELECAO, ID_GRUPO_SELECAO) VALUES ('Isl�ndia',4)
INSERT INTO TB_SELECAO(DS_SELECAO, ID_GRUPO_SELECAO) VALUES ('Cro�cia',4)
INSERT INTO TB_SELECAO(DS_SELECAO, ID_GRUPO_SELECAO) VALUES ('Nig�ria',4)

INSERT INTO TB_SELECAO(DS_SELECAO, ID_GRUPO_SELECAO) VALUES ('Brasil',5)
INSERT INTO TB_SELECAO(DS_SELECAO, ID_GRUPO_SELECAO) VALUES ('Su��a',5)
INSERT INTO TB_SELECAO(DS_SELECAO, ID_GRUPO_SELECAO) VALUES ('Costa Rica',5)
INSERT INTO TB_SELECAO(DS_SELECAO, ID_GRUPO_SELECAO) VALUES ('S�rvia',5)

INSERT INTO TB_SELECAO(DS_SELECAO, ID_GRUPO_SELECAO) VALUES ('Alemanha',6)
INSERT INTO TB_SELECAO(DS_SELECAO, ID_GRUPO_SELECAO) VALUES ('M�xico',6)
INSERT INTO TB_SELECAO(DS_SELECAO, ID_GRUPO_SELECAO) VALUES ('Su�cia',6)
INSERT INTO TB_SELECAO(DS_SELECAO, ID_GRUPO_SELECAO) VALUES ('Coreia do Sul',6)

INSERT INTO TB_SELECAO(DS_SELECAO, ID_GRUPO_SELECAO) VALUES ('B�lgica',7)
INSERT INTO TB_SELECAO(DS_SELECAO, ID_GRUPO_SELECAO) VALUES ('Panam�',7)
INSERT INTO TB_SELECAO(DS_SELECAO, ID_GRUPO_SELECAO) VALUES ('Tun�sia',7)
INSERT INTO TB_SELECAO(DS_SELECAO, ID_GRUPO_SELECAO) VALUES ('Inglaterra',7)

INSERT INTO TB_SELECAO(DS_SELECAO, ID_GRUPO_SELECAO) VALUES ('Pol�nia',8)
INSERT INTO TB_SELECAO(DS_SELECAO, ID_GRUPO_SELECAO) VALUES ('Senegal',8)
INSERT INTO TB_SELECAO(DS_SELECAO, ID_GRUPO_SELECAO) VALUES ('Col�mbia',8)
INSERT INTO TB_SELECAO(DS_SELECAO, ID_GRUPO_SELECAO) VALUES ('Jap�o',8)

INSERT INTO TB_POSICAO VALUES ('Goleiro');
INSERT INTO TB_POSICAO VALUES ('Zagueiro');
INSERT INTO TB_POSICAO VALUES ('Lateral esquerdo');
INSERT INTO TB_POSICAO VALUES ('Goleiro direito');
INSERT INTO TB_POSICAO VALUES ('Volante');
INSERT INTO TB_POSICAO VALUES ('Meio Campo');
INSERT INTO TB_POSICAO VALUES ('Atacante');

INSERT INTO TB_FASE VALUES('CLASSIFICAT�RIO')
INSERT INTO TB_FASE VALUES('OITAVAS')
INSERT INTO TB_FASE VALUES('QUARTAS')
INSERT INTO TB_FASE VALUES('SEMI')
INSERT INTO TB_FASE VALUES('TERCEIRO LUGAR')
INSERT INTO TB_FASE VALUES('FINAL')

INSERT INTO TB_JOGADOR (DS_NOME, NR_NUMERO, ID_POSICAO_JOGADOR, ID_SELECAO_JOGADOR) VALUES ('Neymar Jr.', 10, 7, 17)

INSERT INTO TB_PARTIDA (DT_PARTIDA, ID_FASE_PARTIDA, ID_ESTADIO_PARTIDA) VALUES (GETDATE(), 1,1)
INSERT INTO TB_PARTIDA (DT_PARTIDA, ID_FASE_PARTIDA, ID_ESTADIO_PARTIDA) VALUES (GETDATE(), 1,3)
INSERT INTO TB_PARTIDA (DT_PARTIDA, ID_FASE_PARTIDA, ID_ESTADIO_PARTIDA) VALUES (GETDATE(), 2,4)

INSERT INTO TB_PLACAR (ID_PARTIDA_PLACAR, ID_SELECAO, BL_MANDANTE, NR_GOL, NR_GOL_PRORROGACAO, NR_GOL_DECISAO_PENALTIS) VALUES (1, 17, 1, 3, 0, 0)
INSERT INTO TB_PLACAR (ID_PARTIDA_PLACAR, ID_SELECAO, BL_MANDANTE, NR_GOL, NR_GOL_PRORROGACAO, NR_GOL_DECISAO_PENALTIS) VALUES (1, 18, 0, 0, 0, 0)
INSERT INTO TB_PLACAR (ID_PARTIDA_PLACAR, ID_SELECAO, BL_MANDANTE, NR_GOL, NR_GOL_PRORROGACAO, NR_GOL_DECISAO_PENALTIS) VALUES (2, 1, 1, 3, 0, 0)
INSERT INTO TB_PLACAR (ID_PARTIDA_PLACAR, ID_SELECAO, BL_MANDANTE, NR_GOL, NR_GOL_PRORROGACAO, NR_GOL_DECISAO_PENALTIS) VALUES (2, 2, 0, 2, 0, 0)
INSERT INTO TB_PLACAR (ID_PARTIDA_PLACAR, ID_SELECAO, BL_MANDANTE, NR_GOL, NR_GOL_PRORROGACAO, NR_GOL_DECISAO_PENALTIS) VALUES (3, 10, 1, 2, 1, 5)
INSERT INTO TB_PLACAR (ID_PARTIDA_PLACAR, ID_SELECAO, BL_MANDANTE, NR_GOL, NR_GOL_PRORROGACAO, NR_GOL_DECISAO_PENALTIS) VALUES (3, 15, 0, 2, 1, 4)

SELECT a.DS_NOME, a.NR_NUMERO, c.DS_POSICAO, b.DS_SELECAO,
a.DS_IMAGEM_JOGADOR, b.DS_IMAGEM_BANDEIRA, d.DS_GRUPO
FROM TB_JOGADOR a
INNER JOIN TB_SELECAO b ON a.ID_SELECAO_JOGADOR = b.ID_SELECAO
INNER JOIN TB_POSICAO c ON a.ID_POSICAO_JOGADOR = c.ID_POSICAO
INNER JOIN TB_GRUPO d ON b.ID_GRUPO_SELECAO = d.ID_GRUPO

SELECT a.ID_PARTIDA, a.DT_PARTIDA, a.DS_PARTIDA, p1.ID_PLACAR ID_SELECAO_1, p2.ID_PLACAR  ID_SELECAO_2, 
s1.DS_SELECAO + ' ' + CONVERT(VARCHAR(50), p1.NR_GOL + ISNULL(p1.NR_GOL_PRORROGACAO, 0)) 
+ CASE p1.NR_GOL_DECISAO_PENALTIS WHEN 0 THEN '' ELSE '(' + CONVERT(VARCHAR(50), p1.NR_GOL_DECISAO_PENALTIS) + ')' END
+ ' X ' 
+ CASE p2.NR_GOL_DECISAO_PENALTIS WHEN 0 THEN '' ELSE '(' + CONVERT(VARCHAR(50), p2.NR_GOL_DECISAO_PENALTIS) + ')' END
+  CONVERT(VARCHAR(50), p2.NR_GOL + ISNULL(p2.NR_GOL_PRORROGACAO, 0)) + ' ' + s2.DS_SELECAO DS_PLACAR,
f.DS_FASE, g1.DS_GRUPO GRUPO_SELECAO_1, g2.DS_GRUPO GRUPO_SELECAO_2,
s1.DS_IMAGEM_BANDEIRA BANDEIRA_1, s1.DS_TIPO_IMAGEM_BANDEIRA TIPO_IMAGEM_BANDEIRA_1, s1.DS_CAMINHO_IMAGEM_BANDEIRA CAMINHO_IMAGEM_BANDEIRA_1,
s2.DS_IMAGEM_BANDEIRA BANDEIRA_2, s2.DS_TIPO_IMAGEM_BANDEIRA TIPO_IMAGEM_BANDEIRA_2, s2.DS_CAMINHO_IMAGEM_BANDEIRA CAMINHO_IMAGEM_BANDEIRA_2,
e.DS_ESTADIO, e.DS_CIDADE, e.DS_CAPACIDADE, e.DS_IMAGEM_ESTADIO, e.DS_TIPO_IMAGEM_ESTADIO, e.DS_CAMINHO_IMAGEM_ESTADIO
FROM TB_PARTIDA a 
INNER JOIN TB_PLACAR p1 ON a.ID_PARTIDA = p1.ID_PARTIDA_PLACAR AND p1.BL_MANDANTE = 1
INNER JOIN TB_PLACAR p2 ON a.ID_PARTIDA = p2.ID_PARTIDA_PLACAR AND p2.BL_MANDANTE = 0
INNER JOIN TB_SELECAO s1 ON p1.ID_SELECAO = s1.ID_SELECAO
INNER JOIN TB_SELECAO s2 ON p2.ID_SELECAO = s2.ID_SELECAO
INNER JOIN TB_FASE f ON a.ID_FASE_PARTIDA = f.ID_FASE
INNER JOIN TB_ESTADIO e ON a.ID_ESTADIO_PARTIDA = e.ID_ESTADIO
INNER JOIN TB_GRUPO g1 ON s1.ID_GRUPO_SELECAO = g1.ID_GRUPO
INNER JOIN TB_GRUPO g2 ON s2.ID_GRUPO_SELECAO = g2.ID_GRUPO



