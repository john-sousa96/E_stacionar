CREATE DATABASE bd_estacionamentos
use bd_estacionamentos
go

CREATE TABLE tbl_usuario (
  id_CPF_usuario VARCHAR(11) NOT NULL,
  nome_usuario VARCHAR(100) NOT NULL,
  ddd_cel numeric(2) NOT NULL,
  cel_usuario numeric (9) NOT NULL,
  email_usuario VARCHAR (100) NOT NULL,
  senha_usuario VARCHAR(30) NOT NULL,
  status_usuario INT NOT NULL,
  permissao INT NOT NULL DEFAULT 4,
  PRIMARY KEY(id_CPF_usuario)
)



Select * from tbl_usuario

CREATE TABLE tbl_token (
  id_token Numeric(10) NOT NULL identity,
  status_token int,
  PRIMARY KEY(id_token)
)

Alter table tbl_token
add status_token int 

CREATE TABLE tbl_empresa (
  id_cnpj_empresa VARCHAR(14) NOT NULL,
  nome_empresa VARCHAR(100) NOT NULL,
  nome_proprietario_empresa VARCHAR(200) NOT NULL,
  ddd_empresa VARCHAR(2) NOT NULL,
  tel_empresa VARCHAR(8) NOT NULL,
  ramal_tel_empresa VARCHAR(10) NULL,
  email_empresa VARCHAR(70) NOT NULL,
  tipo_logradouro_empresa_sede VARCHAR(20) NOT NULL,
  logradouro_empresa_sede VARCHAR(150) NOT NULL,
  numero_logradouro_empresa_sede VARCHAR(10) NOT NULL,
  complemento_empresa_sede VARCHAR(200) NULL,
  cep_empresa_sede VARCHAR(8) NOT NULL,
  cidade_empresa_sede VARCHAR(100) NOT NULL,
  estado_empresa_sede VARCHAR(2) NOT NULL,
  pais_empresa_sede VARCHAR(50) NOT NULL,
  senha_empresa VARCHAR(30) NOT NULL,
  status_empresa INT NOT NULL DEFAULT 1,
  permissao INT NULL DEFAULT 2,
  PRIMARY KEY(id_cnpj_empresa)
)

CREATE TABLE tbl_equipamento (
  id_equipamento Numeric (10) NOT NULL identity,
  desc_equipamento VARCHAR(50) NULL,
  PRIMARY KEY(id_equipamento)
)


CREATE TABLE tbl_estacionamento (
  id_estacionamento Numeric(15) NOT NULL identity,
  tbl_empresa_id_cnpj_empresa VARCHAR(14) NOT NULL,
  tipo_logradouro_est VARCHAR(20) NOT NULL,
  logradouro_est VARCHAR(150) NOT NULL,
  numero_est VARCHAR(10) NOT NULL,
  complemento_est VARCHAR(200) NULL,
  CEP_est VARCHAR(8) NOT NULL,
  bairro_est VARCHAR(30) NOT NULL,
  regiao_est VARCHAR(10) NOT NULL,
  cidade_est VARCHAR(100) NOT NULL,
  estado_est VARCHAR(2) NOT NULL,
  pais_est VARCHAR(50) NOT NULL,
  status_est INT NOT NULL DEFAULT 1,
  ddd_tel_est VARCHAR(2) NULL,
  tel_est VARCHAR(9) NULL,
  ramal_est VARCHAR(10) NULL,
  PRIMARY KEY(id_estacionamento),
  INDEX tbl_estacionamento_FKIndex1(tbl_empresa_id_cnpj_empresa),
  FOREIGN KEY(tbl_empresa_id_cnpj_empresa)
    REFERENCES tbl_empresa(id_cnpj_empresa)
      ON DELETE NO ACTION
	  );

CREATE TABLE tbl_funcionario_est (
  id_func numeric(15) NOT NULL identity,
  tbl_estacionamento_id_estacionamento numeric(15) NOT NULL,
  nome_completo_func VARCHAR(200) NOT NULL,
  CPF_func VARCHAR(11) NOT NULL,
  cargo_func VARCHAR(20) NOT NULL,
  senha_func VARCHAR(30) NOT NULL,
  status_func INT NOT NULL DEFAULT 1,
  permissao INt NOT NULL DEFAULT 3,
  PRIMARY KEY(id_func),
  INDEX tbl_funcionario_est_FKIndex1(tbl_estacionamento_id_estacionamento),
  FOREIGN KEY(tbl_estacionamento_id_estacionamento)
    REFERENCES tbl_estacionamento(id_estacionamento)
      ON DELETE NO ACTION
     
);

CREATE TABLE tbl_veiculos (
  id_placa_veiculo VARCHAR(8) NOT NULL,
  tbl_token_id_token numeric(10) NULL,
  cidade_veiculo VARCHAR(100) NULL,
  estado_veiculo VARCHAR(2) NULL,
  nome_prop_veiculo VARCHAR(150) NOT NULL,
  marca_veiculo VARCHAR(30) NOT NULL,
  modelo_veiculo VARCHAR(20) NOT NULL,
  cor_veiculo VARCHAR(20) NOT NULL,
  seguro_veiculo int NOT NULL DEFAULT 0,
  PRIMARY KEY(id_placa_veiculo),
  INDEX tbl_veiculos_FKIndex1(tbl_token_id_token),
  
  FOREIGN KEY(tbl_token_id_token)
    REFERENCES tbl_token(id_token),
         
);


CREATE TABLE tbl_user_veiculo (
	id_CPF_usuario VARCHAR(11) NOT NULL,
	id_placa_veiculo VARCHAR(8) NOT NULL,

	FOREIGN KEY(id_CPF_usuario)
    REFERENCES tbl_usuario(id_CPF_usuario),

	FOREIGN KEY(id_placa_veiculo)
    REFERENCES tbl_veiculos(id_placa_veiculo),


)


CREATE TABLE tbl_vaga (
  id_vaga numeric(10) NOT NULL identity,
  tbl_equipamento_id_equipamento numeric(10)  NOT NULL,
  tbl_estacionamento_id_estacionamento numeric(15) NOT NULL,
  local_vaga VARCHAR(10) NOT NULL,
  descricao_vaga VARCHAR(50) NULL,
  status_vaga INT NOT NULL,
  PRIMARY KEY(id_vaga),
  INDEX tbl_vaga_FKIndex1(tbl_estacionamento_id_estacionamento),
  INDEX tbl_vaga_FKIndex2(tbl_equipamento_id_equipamento),
  FOREIGN KEY(tbl_estacionamento_id_estacionamento)
    REFERENCES tbl_estacionamento(id_estacionamento),
  FOREIGN KEY(tbl_equipamento_id_equipamento)
    REFERENCES tbl_equipamento(id_equipamento)
      
);

CREATE TABLE tbl_servico (
  id_servico numeric(10) NOT NULL identity,
  tbl_estacionamento_id_estacionamento numeric(15) NOT NULL,
  desc_servico VARCHAR(60) NOT NULL,
  valor_servico DECIMAL NOT NULL,
  status_2 INT NOT NULL DEFAULT 1,
  PRIMARY KEY(id_servico),
  INDEX tbl_servico_FKIndex1(tbl_estacionamento_id_estacionamento),
  FOREIGN KEY(tbl_estacionamento_id_estacionamento)
    REFERENCES tbl_estacionamento(id_estacionamento)
     
);

Alter table tbl_servico
add desc_servico varchar(60)

use bd_estacionamentos
go

CREATE TABLE tbl_reservas (
  id_reserva numeric(20) NOT NULL identity,
  tbl_vaga_id_vaga numeric(10) NOT NULL,
  tbl_token_id_token numeric(10) NULL,
  tbl_usuario_id_CPF_usuario VARCHAR(11) NOT NULL,
  tbl_servico_id_servico numeric(10) NOT NULL,
  timestamp_inicio_reserva DATETIME NOT NULL,
  timestamp_final_reserva DATETIME NOT NULL,
  valor_servico_reserva DECIMAL(6,2) NULL,
  PRIMARY KEY(id_reserva),
  INDEX tbl_reservas_FKIndex1(tbl_servico_id_servico),
  INDEX tbl_reservas_FKIndex2(tbl_usuario_id_CPF_usuario),
  INDEX tbl_reservas_FKIndex3(tbl_token_id_token),
  INDEX tbl_reservas_FKIndex4(tbl_vaga_id_vaga),
  FOREIGN KEY(tbl_servico_id_servico)
    REFERENCES tbl_servico(id_servico)
	ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(tbl_usuario_id_CPF_usuario)
    REFERENCES tbl_usuario(id_CPF_usuario)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(tbl_token_id_token)
    REFERENCES tbl_token(id_token)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(tbl_vaga_id_vaga)
    REFERENCES tbl_vaga(id_vaga)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
);



CREATE TABLE tbl_uso (
  id_nota_fiscal_uso numeric(20) NOT NULL identity,
  tbl_vaga_id_vaga numeric(10) NOT NULL,
  tbl_token_id_token numeric(10) NOT NULL,
  tbl_usuario_id_CPF_usuario VARCHAR(11) NOT NULL,
  tbl_servico_id_servico numeric(10) NOT NULL,
  timestamp_final_uso DATETIME NULL,
  timestamp_inicio_uso DATETIME NULL,
  valor_servico_uso DECIMAL(6,2) NULL,
  PRIMARY KEY(id_nota_fiscal_uso),
  INDEX tbl_uso_FKIndex1(tbl_usuario_id_CPF_usuario),
  INDEX tbl_uso_FKIndex3(tbl_servico_id_servico),
  INDEX tbl_uso_FKIndex4(tbl_token_id_token),
  INDEX tbl_uso_FKIndex5(tbl_vaga_id_vaga),
  FOREIGN KEY(tbl_usuario_id_CPF_usuario)
    REFERENCES tbl_usuario(id_CPF_usuario)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(tbl_servico_id_servico)
    REFERENCES tbl_servico(id_servico)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(tbl_token_id_token)
    REFERENCES tbl_token(id_token)
	ON DELETE NO ACTION
      ON UPDATE NO ACTION,
      
  FOREIGN KEY(tbl_vaga_id_vaga)
    REFERENCES tbl_vaga(id_vaga)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
);





insert tbl_empresa values
('00000000001234','Empresa de estacionamento teste 1', 'Jos� da Silva', '11','12345678', '002', 'empresateste1@email.com', 'Avenida', 'das sedes', '1234A', 'sala 20, 10� andar', '00021668', 'S�o Paulo', 'SP', 'Brasil', 'SenhaTeste2020*', '1','2' ),
('00000000001235','Empresa de estacionamento teste 2', 'Maria dos Santos', '21','12347895', '003', 'empresateste2@email.com', 'Rua', 'dos testes', '5678', 'sala 10, 2� andar', '00026756', 'Rio de Janeiro', 'RJ', 'Brasil', 'SenhaTeste2020*', '1','2' )

Select * from tbl_empresa

insert tbl_equipamento (desc_equipamento) values 

('controle de vagas'),
('controle de vagas'),
('controle de vagas'),
('controle de vagas'),
('controle de vagas'),
('controle de vagas'), 
('controle de vagas'),
('controle de vagas'),
('controle de vagas'),
('controle de vagas')

Select * from tbl_equipamento

SET IDENTITY_INSERT tbl_estacionamento OFF 

insert tbl_estacionamento (id_estacionamento,tbl_empresa_id_cnpj_empresa,tipo_logradouro_est, logradouro_est, numero_est,complemento_est, CEP_est, bairro_est, regiao_est, cidade_est, estado_est,pais_est, status_est, ddd_tel_est, tel_est, ramal_est) values

 

(14567791234567, '00000000001234', 'Rua', 'teste de rua', '123', 'entrada pelos fundos da empresa X', '02231987', 'S�', 'centro', 'S�o Paulo', 'SP', 'Brasil', 1, '11', '32145678', '32'),
(34567891234568, '00000000001234', 'Rua', 'teste de rua 2', '124', 'entrada pelos fundos da empresa X', '02231945', 'Pinheiros', 'Oeste ', 'S�o Paulo', 'SP', 'Brasil', 1, '11', '32145677', '32'),
(34567891234569, '00000000001234', 'Rua', 'teste de rua 3', '123', 'entrada pelos fundos da empresa X', '02219687', 'Graja�', 'Sul', 'S�o Paulo', 'SP', 'Brasil', 1, '11', '32145678', '32'),
(34567891234570, '00000000001234', 'Rua', 'teste de rua 4', '123', 'entrada pelos fundos da empresa X', '02231756', 'Tatuap�', 'Leste', 'S�o Paulo', 'SP', 'Brasil', 1, '11', '32145657', '32'),
(34567891234571, '00000000001234', 'Rua', 'teste de rua 5', '123', 'entrada pelos fundos da empresa X', '02231578', 'Santana', 'Norte', 'S�o Paulo', 'SP', 'Brasil', 1, '11', '32145658', '32'),
(34567891234502, '00000000001235', 'Avenida', 'Atl�ntica ', '123', 'entrada pelos fundos da empresa X', '02231945', 'Copacabana', 'Sul', 'Rio de Janeiro', 'RJ', 'Brasil', 1, '21', '45145678', '02'),
(34567891234503, '00000000001235', 'Avenida', 'X ', '123', 'entrada pelos fundos da empresa X', '02234545', 'Gl�ria', 'Centro', 'Rio de Janeiro', 'RJ', 'Brasil', 1, '21', '45145678', '12'),
(34567891234504, '00000000001235', 'Travessa', 'Y ', '123', 'entrada pelos fundos da empresa X', '02248945', 'Mar�', ' Norte', 'Rio de Janeiro', 'RJ', 'Brasil', 1, '21', '45145878', '01'),
(34567891234505, '00000000001235', 'Rodovia', 'da Barra ', '123', 'entrada pelos fundos da empresa X', '02231945', 'Barra da Tijuca', 'Oeste', 'Rio de Janeiro', 'RJ', 'Brasil', 1, '21', '45149678', '02')

Select * from tbl_estacionamento

Insert tbl_funcionario_est (tbl_estacionamento_id_estacionamento, nome_completo_func, CPF_func, cargo_func,senha_func) values

(14567791234567, 'Jos� Souza', '213546789', 'Caixa', 'CaIxa123*'),
(34567891234568, 'Lucas Silva', '21354489', 'Caixa', 'CaIxa123*'),
(34567891234569, 'Maria Ant�nia', '213541234', 'Caixa', 'CaIxa123*'),
(34567891234570, 'Carlos Jos�', '2135461234', 'Caixa', 'CaIxa123*'), 
(34567891234571, 'Maria Jos�', '2135461234', 'Caixa', 'CaIxa123*'), 
(34567891234502, 'William da Silva', '21354671234', 'Caixa', 'CaIxa123*'),
(34567891234503, 'Cla�dio', '21354968', 'Caixa', 'CaIxa123*'),
(34567891234504, 'Cl�vis', '213547894', 'Caixa', 'CaIxa123*'),
(34567891234505, 'Ronaldo', '213546789', 'Caixa', 'CaIxa123*'), 
(14567791234567, 'Enzo', '213542345', 'Caixa', 'CaIxa123*')

SET IDENTITY_INSERT tbl_funcionario_est OFF

Insert tbl_funcionario_est (id_func, tbl_estacionamento_id_estacionamento, nome_completo_func, CPF_func, cargo_func,senha_func, permissao) values

(19041996, 14567791234567,'Adminstrador', '33344466699', 'Administrador', '*Estacionar2020*',0)

Select * from tbl_funcionario_est

insert tbl_token (status_token) values
(1),
(1),
(1),
(1),
(1),
(1),
(1),
(1),
(1),
(1),
(1),
(1),
(1)

use bd_estacionamentos
go

Select * from tbl_token

insert tbl_servico (tbl_estacionamento_id_estacionamento, desc_servico, valor_servico) values
(14567791234567, 'estacionar em vaga descoberta', 10.00),
(14567791234567, 'estacionar em vaga coberta', 20),
(14567791234567, 'vallet', 10),
(34567891234568, 'estacionar em vaga descoberta', 10),
(34567891234568, 'estacionar em vaga coberta', 20),
(34567891234568, 'vallet', 10),
(34567891234569, 'estacionar em vaga descoberta', 10),
(34567891234569, 'estacionar em vaga coberta', 20),
(34567891234569, 'vallet', 10),
(34567891234502, 'estacionar em vaga descoberta', 10),
(34567891234502, 'estacionar em vaga coberta', 20),
(34567891234502, 'vallet', 10)


Select * from tbl_servico

insert tbl_usuario (id_CPF_usuario, nome_usuario, ddd_cel, cel_usuario, email_usuario, senha_usuario, status_usuario) values

('00000001234', 'Usu�rio teste', 11, 97777568, 'usuario@mail.com', 'senhausuario', 1),
('00000001235', 'Usu�rio teste 2', 21, 97777575, 'usuario2@mail.com', 'senhausuario', 1)

Select * from tbl_usuario

insert tbl_veiculos (id_placa_veiculo, tbl_token_id_token, nome_prop_veiculo, cidade_veiculo, estado_veiculo, marca_veiculo, modelo_veiculo, cor_veiculo, seguro_veiculo) values
('AAA1234', 1, 'Maria de Souza', 'S�o Paulo', 'SP', 'Citroen', 'C3', 'vermelho', 1),  
('BBB4321', 2, 'Jos� dos Santos', 'Rio de Janeiro', 'RJ', 'Fiat', 'uno', 'vermelho', 1)

Select * from tbl_veiculos

Select * from tbl_equipamento

insert tbl_vaga (tbl_equipamento_id_equipamento, tbl_estacionamento_id_estacionamento, local_vaga, status_vaga) values 

(2, 14567791234567, 'B1', 1),
(3, 14567791234567, 'C2', 1),
(4, 14567791234567, 'A1', 1),
(5, 34567891234568, 'A1', 1),
(6, 34567891234568, 'B2', 1),
(7, 34567891234568, 'C3', 1),
(8, 34567891234569, 'A1', 1),
(9, 34567891234569, 'B2', 1),
(10, 34567891234569, 'C3', 1),
(11, 34567891234502, 'A1', 1)

Select * from tbl_vaga

use bd_estacionamentos
go



insert tbl_uso (tbl_vaga_id_vaga, tbl_token_id_token, tbl_usuario_id_CPF_usuario, tbl_servico_id_servico, timestamp_inicio_uso, timestamp_final_uso, valor_servico_uso) values
/*(2, 1, '00000001234',1, '2020-09-13 18:43:59.953', CURRENT_TIMESTAMP, 10),
(3, 1, '00000001234',1, '2020-09-13 18:43:59.953', CURRENT_TIMESTAMP, 10),
(4, 1, '00000001234',1, '2020-09-13 18:43:59.953', CURRENT_TIMESTAMP, 10),
(5, 1, '00000001234',1, '2020-09-13 18:43:59.953', CURRENT_TIMESTAMP, 10),
(6, 1, '00000001234',1, '2020-09-13 18:43:59.953', CURRENT_TIMESTAMP, 10),
(7, 1, '00000001234',1, '2020-09-13 18:43:59.953', CURRENT_TIMESTAMP, 10),
(8, 1, '00000001234',1, '2020-09-13 18:43:59.953', CURRENT_TIMESTAMP, 10),
(9, 1, '00000001234',1, '2020-09-13 18:43:59.953', CURRENT_TIMESTAMP, 10),
(10, 1, '00000001234',1, '2020-09-13 18:43:59.953', CURRENT_TIMESTAMP, 10),
(11, 1, '00000001234',1, '2020-09-13 18:43:59.953', CURRENT_TIMESTAMP, 10),
(2, 2, '00000001234',1, '2020-09-13 18:43:59.953', CURRENT_TIMESTAMP, 10),
(3, 2, '00000001234',1, '2020-09-13 18:43:59.953', CURRENT_TIMESTAMP, 10),
(4, 12, '00000001234',1, '2020-09-13 18:43:59.953', CURRENT_TIMESTAMP, 10),
(5, 2, '00000001234',1, '2020-09-13 18:43:59.953', CURRENT_TIMESTAMP, 10),
(6, 2, '00000001234',1, '2020-09-13 18:43:59.953', CURRENT_TIMESTAMP, 10),
(7, 2, '00000001234',1, '2020-09-13 18:43:59.953', CURRENT_TIMESTAMP, 10),
(8, 2, '00000001234',1, '2020-09-13 18:43:59.953', CURRENT_TIMESTAMP, 10),
(9, 2, '00000001234',1, '2020-09-13 18:43:59.953', CURRENT_TIMESTAMP, 10),
(10, 2, '00000001234',1, '2020-09-13 18:43:59.953', CURRENT_TIMESTAMP, 10),
(11, 2, '00000001234',1, '2020-09-13 18:43:59.953', CURRENT_TIMESTAMP, 10),
(2, 1, '00000001234',1, '2020-09-12 17:43:59.953', CURRENT_TIMESTAMP, 10),
(3, 1, '00000001234',1, '2020-09-11 14:43:59.953', CURRENT_TIMESTAMP, 10),
(4, 1, '00000001234',1, '2020-09-10 12:43:59.953', CURRENT_TIMESTAMP, 10),
(5, 1, '00000001234',1, '2020-09-08 11:43:59.953', CURRENT_TIMESTAMP, 10),
(6, 1, '00000001234',1, '2020-09-09 10:43:59.953', CURRENT_TIMESTAMP, 10),
(7, 1, '00000001234',1, '2020-09-10 08:43:59.953', CURRENT_TIMESTAMP, 10),
(8, 1, '00000001234',1, '2020-09-01 08:43:59.953', CURRENT_TIMESTAMP, 10),
(9, 1, '00000001234',1, '2020-09-02 18:43:59.953', CURRENT_TIMESTAMP, 10),
(10, 1, '00000001234',1, '2020-09-03 08:43:59.953', CURRENT_TIMESTAMP, 10),
(11, 1, '00000001234',1, '2020-09-11 18:43:59.953', CURRENT_TIMESTAMP, 10),
(2, 2, '00000001234',1, '2020-09-12 18:43:59.953', CURRENT_TIMESTAMP, 10),
(3, 2, '00000001234',1, '2020-09-05 18:43:59.953', CURRENT_TIMESTAMP, 10),
(4, 12, '00000001234',1, '2020-09-11 18:43:59.953', CURRENT_TIMESTAMP, 10),
(5, 2, '00000001234',1, '2020-09-09 18:43:59.953', CURRENT_TIMESTAMP, 10),
(6, 2, '00000001234',1, '2020-09-07 18:43:59.953', CURRENT_TIMESTAMP, 10),
(7, 2, '00000001234',1, '2020-09-06 18:43:59.953', CURRENT_TIMESTAMP, 10),
(8, 2, '00000001234',1, '2020-09-03 18:43:59.953', CURRENT_TIMESTAMP, 10),
(9, 2, '00000001234',1, '2020-09-04 18:43:59.953', CURRENT_TIMESTAMP, 10),
(10, 2, '00000001234',1, '2020-09-05 18:43:59.953', CURRENT_TIMESTAMP, 10),
(11, 2, '00000001234',1, '2020-09-06 18:43:59.953', CURRENT_TIMESTAMP, 10),
(2, 1, '00000001234',2, '2020-09-13 18:43:59.953', CURRENT_TIMESTAMP, 100),
(3, 1, '00000001234',2, '2020-09-13 18:43:59.953', CURRENT_TIMESTAMP, 30),
(4, 1, '00000001234',2, '2020-09-13 18:43:59.953', CURRENT_TIMESTAMP, 40),
(5, 1, '00000001234',2, '2020-09-13 18:43:59.953', CURRENT_TIMESTAMP, 30),
(6, 1, '00000001234',3, '2020-09-13 18:43:59.953', CURRENT_TIMESTAMP, 30),
(7, 1, '00000001234',4, '2020-09-13 18:43:59.953', CURRENT_TIMESTAMP, 20),
(8, 1, '00000001234',5, '2020-09-13 18:43:59.953', CURRENT_TIMESTAMP, 30),
(9, 1, '00000001234',6, '2020-09-13 18:43:59.953', CURRENT_TIMESTAMP, 30),
(10, 1, '00000001234',6, '2020-09-13 18:43:59.953', CURRENT_TIMESTAMP, 60),
(11, 1, '00000001234',2, '2020-09-13 18:43:59.953', CURRENT_TIMESTAMP, 120),
(2, 2, '00000001234',6, '2020-09-13 18:43:59.953', CURRENT_TIMESTAMP, 130),
(3, 2, '00000001234',6, '2020-09-13 18:43:59.953', CURRENT_TIMESTAMP, 20),
(4, 12, '00000001234',6, '2020-09-13 18:43:59.953', CURRENT_TIMESTAMP, 40),
(5, 2, '00000001234',6, '2020-09-13 18:43:59.953', CURRENT_TIMESTAMP, 15),
(6, 2, '00000001234',6, '2020-09-13 18:43:59.953', CURRENT_TIMESTAMP, 9),
(7, 2, '00000001234',6, '2020-09-13 18:43:59.953', CURRENT_TIMESTAMP, 90),
(8, 2, '00000001234',6, '2020-09-13 18:43:59.953', CURRENT_TIMESTAMP, 120),
(9, 2, '00000001234',4, '2020-09-13 18:43:59.953', CURRENT_TIMESTAMP, 100),
(10, 2, '00000001234',4, '2020-09-13 18:43:59.953', CURRENT_TIMESTAMP, 120),
(11, 2, '00000001234',4, '2020-09-13 18:43:59.953', CURRENT_TIMESTAMP, 2),
(2, 1, '00000001234',4, '2020-09-12 17:43:59.953', CURRENT_TIMESTAMP, 20),
(3, 1, '00000001234',4, '2020-09-11 14:43:59.953', CURRENT_TIMESTAMP, 150),
(4, 1, '00000001234',3, '2020-09-10 12:43:59.953', CURRENT_TIMESTAMP, 30),
(5, 1, '00000001234',6, '2020-09-08 11:43:59.953', CURRENT_TIMESTAMP, 20),
(6, 1, '00000001234',5, '2020-09-09 10:43:59.953', CURRENT_TIMESTAMP, 20),
(7, 1, '00000001234',4, '2020-09-10 08:43:59.953', CURRENT_TIMESTAMP, 30),
(8, 1, '00000001234',5, '2020-09-01 08:43:59.953', CURRENT_TIMESTAMP, 40),
(9, 1, '00000001234',6, '2020-09-02 18:43:59.953', CURRENT_TIMESTAMP, 10),
(10, 1, '00000001234',6, '2020-09-03 08:43:59.953', CURRENT_TIMESTAMP, 50),
(11, 1, '00000001234',7, '2020-09-11 18:43:59.953', CURRENT_TIMESTAMP, 60),
(2, 2, '00000001234',1, '2020-09-12 18:43:59.953', CURRENT_TIMESTAMP, 80),
(3, 2, '00000001234',1, '2020-09-05 18:43:59.953', CURRENT_TIMESTAMP, 10),
(4, 12, '00000001234',1, '2020-09-11 18:43:59.953', CURRENT_TIMESTAMP, 10),
(5, 2, '00000001234',7, '2020-09-09 18:43:59.953', CURRENT_TIMESTAMP, 10),
(6, 2, '00000001234',7, '2020-09-07 18:43:59.953', CURRENT_TIMESTAMP, 10),
(7, 2, '00000001234',7, '2020-09-06 18:43:59.953', CURRENT_TIMESTAMP, 10),
(8, 2, '00000001234',4, '2020-09-03 18:43:59.953', CURRENT_TIMESTAMP, 10),
(9, 2, '00000001234',4, '2020-09-04 18:43:59.953', CURRENT_TIMESTAMP, 10),
(10, 2, '00000001234',4, '2020-09-05 18:43:59.953', CURRENT_TIMESTAMP, 10),
(11, 2, '00000001234',3, '2020-09-06 18:43:59.953', CURRENT_TIMESTAMP, 10)*/

use bd_estacionamentos
go
insert tbl_uso (tbl_vaga_id_vaga, tbl_token_id_token, tbl_usuario_id_CPF_usuario, tbl_servico_id_servico, timestamp_inicio_uso, timestamp_final_uso, valor_servico_uso) values

(2, 1, '00000001234',1, '2020-09-15 18:43:59.953', '2020-09-16 23:43:59.953', 10),
(3, 1, '00000001234',1, '2020-09-15 18:43:59.953', '2020-09-16 23:43:59.953', 10),
(4, 1, '00000001234',1, '2020-09-15 18:43:59.953', '2020-09-16 23:43:59.953', 10),
(5, 1, '00000001234',1, '2020-09-15 18:43:59.953','2020-09-16 23:43:59.953', 10),
(6, 1, '00000001234',1, '2020-09-15 18:43:59.953', '2020-09-16 23:43:59.953', 10),
(7, 1, '00000001234',1, '2020-09-15 18:43:59.953','2020-09-16 23:43:59.953', 10),
(8, 1, '00000001234',1, '2020-09-15 18:43:59.953', '2020-09-16 23:43:59.953', 10),
(9, 1, '00000001234',1, '2020-09-15 18:43:59.953', '2020-09-16 23:43:59.953', 10),
(10, 1, '00000001234',1, '2020-09-15 18:43:59.953','2020-09-16 23:43:59.953', 10),
(11, 1, '00000001234',1, '2020-09-15 18:43:59.953', '2020-09-16 23:43:59.953', 10),
(2, 2, '00000001234',1, '2020-09-15 18:43:59.953', '2020-09-16 23:43:59.953', 10),
(3, 2, '00000001234',1, '2020-09-15 18:43:59.953', '2020-09-16 23:43:59.953', 10),
(4, 12, '00000001234',1, '2020-09-15 18:43:59.953', '2020-09-16 23:43:59.953', 10),
(5, 2, '00000001234',1, '2020-09-15 18:43:59.953', '2020-09-16 23:43:59.953', 10),
(6, 2, '00000001234',1, '2020-09-15 18:43:59.953', '2020-09-16 23:43:59.953', 10),
(7, 2, '00000001234',1, '2020-09-15 18:43:59.953','2020-09-16 23:43:59.953', 10),
(8, 2, '00000001234',1, '2020-09-15 18:43:59.953', '2020-09-16 23:43:59.953', 10),
(9, 2, '00000001234',1, '2020-09-15 18:43:59.953','2020-09-16 23:43:59.953', 10),
(10, 2, '00000001234',1, '2020-09-15 18:43:59.953', '2020-09-16 23:43:59.953', 10),
(11, 2, '00000001234',1, '2020-09-15 18:43:59.953', '2020-09-16 23:43:59.953', 10),
(2, 1, '00000001234',1, '2020-09-15 17:43:59.953', '2020-09-16 23:43:59.953', 10),
(3, 1, '00000001234',1, '2020-09-15 14:43:59.953', '2020-09-16 23:43:59.953', 10),
(4, 1, '00000001234',1, '2020-09-15 12:43:59.953', CURRENT_TIMESTAMP, 10),
(5, 1, '00000001234',1, '2020-09-15 11:43:59.953', CURRENT_TIMESTAMP, 10),
(6, 1, '00000001234',1, '2020-09-15 10:43:59.953', CURRENT_TIMESTAMP, 10),
(7, 1, '00000001234',1, '2020-09-15 08:43:59.953', CURRENT_TIMESTAMP, 10),
(8, 1, '00000001234',1, '2020-09-15 08:43:59.953', CURRENT_TIMESTAMP, 10),
(9, 1, '00000001234',1, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 10),
(10, 1, '00000001234',1, '2020-09-16 08:43:59.953', CURRENT_TIMESTAMP, 10),
(11, 1, '00000001234',1, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 10),
(2, 2, '00000001234',1, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 10),
(3, 2, '00000001234',1, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 10),
(4, 12, '00000001234',1, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 10),
(5, 2, '00000001234',1, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 10),
(6, 2, '00000001234',1, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 10),
(7, 2, '00000001234',1, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 10),
(8, 2, '00000001234',1, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 10),
(9, 2, '00000001234',1, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 10),
(10, 2, '00000001234',1, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 10),
(11, 2, '00000001234',1, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 10),
(2, 1, '00000001234',2, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 100),
(3, 1, '00000001234',2, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 30),
(4, 1, '00000001234',2, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 40),
(5, 1, '00000001234',2, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 30),
(6, 1, '00000001234',3, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 30),
(7, 1, '00000001234',4, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 20),
(8, 1, '00000001234',5, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 30),
(9, 1, '00000001234',6, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 30),
(10, 1, '00000001234',6, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 60),
(11, 1, '00000001234',2, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 120),
(2, 2, '00000001234',6, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 130),
(3, 2, '00000001234',6, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 20),
(4, 12, '00000001234',6, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 40),
(5, 2, '00000001234',6, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 15),
(6, 2, '00000001234',6, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 9),
(7, 2, '00000001234',6, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 90),
(8, 2, '00000001234',6, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 120),
(9, 2, '00000001234',4, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 100),
(10, 2, '00000001234',4, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 120),
(11, 2, '00000001234',4, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 2),
(2, 1, '00000001234',4, '2020-09-16 17:43:59.953', CURRENT_TIMESTAMP, 20),
(3, 1, '00000001234',4, '2020-09-16 14:43:59.953', CURRENT_TIMESTAMP, 150),
(4, 1, '00000001234',3, '2020-09-16 12:43:59.953', CURRENT_TIMESTAMP, 30),
(5, 1, '00000001234',6, '2020-09-16 11:43:59.953', CURRENT_TIMESTAMP, 20),
(6, 1, '00000001234',5, '2020-09-16 10:43:59.953', CURRENT_TIMESTAMP, 20),
(7, 1, '00000001234',4, '2020-09-16 08:43:59.953', CURRENT_TIMESTAMP, 30),
(8, 1, '00000001234',5, '2020-09-16 08:43:59.953', CURRENT_TIMESTAMP, 40),
(9, 1, '00000001234',6, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 10),
(10, 1, '00000001234',6, '2020-09-16 08:43:59.953', CURRENT_TIMESTAMP, 50),
(11, 1, '00000001234',7, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 60),
(2, 2, '00000001234',1, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 80),
(3, 2, '00000001234',1, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 10),
(4, 12, '00000001234',1, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 10),
(5, 2, '00000001234',7, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 10),
(6, 2, '00000001234',7, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 10),
(7, 2, '00000001234',7, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 10),
(8, 2, '00000001234',4, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 10),
(9, 2, '00000001234',4, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 10),
(10, 2, '00000001234',4, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 10),
(11, 2, '00000001234',3, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 10)

Select * from tbl_uso

insert tbl_reservas (tbl_vaga_id_vaga, tbl_token_id_token, tbl_usuario_id_CPF_usuario, tbl_servico_id_servico, timestamp_inicio_reserva, timestamp_final_reserva, valor_servico_reserva) values 


(2, 1, '00000001234',1, '2020-09-15 18:43:59.953', '2020-09-16 23:43:59.953', 10),
(3, 1, '00000001234',1, '2020-09-15 18:43:59.953', '2020-09-16 23:43:59.953', 10),
(4, 1, '00000001234',1, '2020-09-15 18:43:59.953', '2020-09-16 23:43:59.953', 10),
(5, 1, '00000001234',1, '2020-09-15 18:43:59.953','2020-09-16 23:43:59.953', 10),
(6, 1, '00000001234',1, '2020-09-15 18:43:59.953', '2020-09-16 23:43:59.953', 10),
(7, 1, '00000001234',1, '2020-09-15 18:43:59.953','2020-09-16 23:43:59.953', 10),
(8, 1, '00000001234',1, '2020-09-15 18:43:59.953', '2020-09-16 23:43:59.953', 10),
(9, 1, '00000001234',1, '2020-09-15 18:43:59.953', '2020-09-16 23:43:59.953', 10),
(10, 1, '00000001234',1, '2020-09-15 18:43:59.953','2020-09-16 23:43:59.953', 10),
(11, 1, '00000001234',1, '2020-09-15 18:43:59.953', '2020-09-16 23:43:59.953', 10),
(2, 2, '00000001234',1, '2020-09-15 18:43:59.953', '2020-09-16 23:43:59.953', 10),
(3, 2, '00000001234',1, '2020-09-15 18:43:59.953', '2020-09-16 23:43:59.953', 10),
(4, 12, '00000001234',1, '2020-09-15 18:43:59.953', '2020-09-16 23:43:59.953', 10),
(5, 2, '00000001234',1, '2020-09-15 18:43:59.953', '2020-09-16 23:43:59.953', 10),
(6, 2, '00000001234',1, '2020-09-15 18:43:59.953', '2020-09-16 23:43:59.953', 10),
(7, 2, '00000001234',1, '2020-09-15 18:43:59.953','2020-09-16 23:43:59.953', 10),
(8, 2, '00000001234',1, '2020-09-15 18:43:59.953', '2020-09-16 23:43:59.953', 10),
(9, 2, '00000001234',1, '2020-09-15 18:43:59.953','2020-09-16 23:43:59.953', 10),
(10, 2, '00000001234',1, '2020-09-15 18:43:59.953', '2020-09-16 23:43:59.953', 10),
(11, 2, '00000001234',1, '2020-09-15 18:43:59.953', '2020-09-16 23:43:59.953', 10),
(2, 1, '00000001234',1, '2020-09-15 17:43:59.953', '2020-09-16 23:43:59.953', 10),
(3, 1, '00000001234',1, '2020-09-15 14:43:59.953', '2020-09-16 23:43:59.953', 10),
(4, 1, '00000001234',1, '2020-09-15 12:43:59.953', CURRENT_TIMESTAMP, 10),
(5, 1, '00000001234',1, '2020-09-15 11:43:59.953', CURRENT_TIMESTAMP, 10),
(6, 1, '00000001234',1, '2020-09-15 10:43:59.953', CURRENT_TIMESTAMP, 10),
(7, 1, '00000001234',1, '2020-09-15 08:43:59.953', CURRENT_TIMESTAMP, 10),
(8, 1, '00000001234',1, '2020-09-15 08:43:59.953', CURRENT_TIMESTAMP, 10),
(9, 1, '00000001234',1, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 10),
(10, 1, '00000001234',1, '2020-09-16 08:43:59.953', CURRENT_TIMESTAMP, 10),
(11, 1, '00000001234',1, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 10),
(2, 2, '00000001234',1, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 10),
(3, 2, '00000001234',1, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 10),
(4, 12, '00000001234',1, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 10),
(5, 2, '00000001234',1, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 10),
(6, 2, '00000001234',1, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 10),
(7, 2, '00000001234',1, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 10),
(8, 2, '00000001234',1, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 10),
(9, 2, '00000001234',1, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 10),
(10, 2, '00000001234',1, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 10),
(11, 2, '00000001234',1, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 10),
(2, 1, '00000001234',2, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 100),
(3, 1, '00000001234',2, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 30),
(4, 1, '00000001234',2, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 40),
(5, 1, '00000001234',2, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 30),
(6, 1, '00000001234',3, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 30),
(7, 1, '00000001234',4, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 20),
(8, 1, '00000001234',5, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 30),
(9, 1, '00000001234',6, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 30),
(10, 1, '00000001234',6, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 60),
(11, 1, '00000001234',2, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 120),
(2, 2, '00000001234',6, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 130),
(3, 2, '00000001234',6, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 20),
(4, 12, '00000001234',6, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 40),
(5, 2, '00000001234',6, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 15),
(6, 2, '00000001234',6, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 9),
(7, 2, '00000001234',6, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 90),
(8, 2, '00000001234',6, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 120),
(9, 2, '00000001234',4, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 100),
(10, 2, '00000001234',4, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 120),
(11, 2, '00000001234',4, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 2),
(2, 1, '00000001234',4, '2020-09-16 17:43:59.953', CURRENT_TIMESTAMP, 20),
(3, 1, '00000001234',4, '2020-09-16 14:43:59.953', CURRENT_TIMESTAMP, 150),
(4, 1, '00000001234',3, '2020-09-16 12:43:59.953', CURRENT_TIMESTAMP, 30),
(5, 1, '00000001234',6, '2020-09-16 11:43:59.953', CURRENT_TIMESTAMP, 20),
(6, 1, '00000001234',5, '2020-09-16 10:43:59.953', CURRENT_TIMESTAMP, 20),
(7, 1, '00000001234',4, '2020-09-16 08:43:59.953', CURRENT_TIMESTAMP, 30),
(8, 1, '00000001234',5, '2020-09-16 08:43:59.953', CURRENT_TIMESTAMP, 40),
(9, 1, '00000001234',6, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 10),
(10, 1, '00000001234',6, '2020-09-16 08:43:59.953', CURRENT_TIMESTAMP, 50),
(11, 1, '00000001234',7, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 60),
(2, 2, '00000001234',1, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 80),
(3, 2, '00000001234',1, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 10),
(4, 12, '00000001234',1, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 10),
(5, 2, '00000001234',7, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 10),
(6, 2, '00000001234',7, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 10),
(7, 2, '00000001234',7, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 10),
(8, 2, '00000001234',4, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 10),
(9, 2, '00000001234',4, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 10),
(10, 2, '00000001234',4, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 10),
(11, 2, '00000001234',3, '2020-09-16 18:43:59.953', CURRENT_TIMESTAMP, 10)

select * from tbl_reservas where id_reserva

use bd_estacionamentos
go
select * from tbl_funcionario_est

insert tbl_uso (tbl_vaga_id_vaga, tbl_token_id_token, tbl_usuario_id_CPF_usuario, tbl_servico_id_servico, timestamp_inicio_uso, valor_servico_uso) values

(2, 1, '00000001234',1, '2020-09-15 18:43:59.953', 10),
(3, 1, '00000001234',1, '2020-09-15 18:43:59.953', 10),
(4, 1, '00000001234',1, '2020-09-15 18:43:59.953', 10),
(5, 1, '00000001234',1, '2020-09-15 18:43:59.953', 10),
(6, 1, '00000001234',1, '2020-09-15 18:43:59.953', 10),
(7, 1, '00000001234',1, '2020-09-15 18:43:59.953', 10),
(8, 1, '00000001234',1, '2020-09-15 18:43:59.953', 10),
(9, 1, '00000001234',1, '2020-09-15 18:43:59.953', 10),
(10, 1, '00000001234',1, '2020-09-15 18:43:59.953', 10),
(11, 1, '00000001234',1, '2020-09-15 18:43:59.953', 10),
(2, 2, '00000001234',1, '2020-09-15 18:43:59.953', 10),
(3, 2, '00000001234',1, '2020-09-15 18:43:59.953', 10),
(4, 12, '00000001234',1, '2020-09-15 18:43:59.953', 10),
(5, 2, '00000001234',1, '2020-09-15 18:43:59.953', 10),
(6, 2, '00000001234',1, '2020-09-15 18:43:59.953', 10)


Select U.id_nota_fiscal_uso, U.valor_servico_uso, U.timestamp_inicio_uso, U.timestamp_final_uso, (DATEDIFF(hour, U.timestamp_inicio_uso, U.timestamp_final_uso) * U.valor_servico_uso) as total, C.nome_usuario, S.desc_servico,v.local_vaga, R.id_placa_veiculo
from  tbl_uso as U inner join tbl_usuario as C on U.tbl_usuario_id_CPF_usuario  = C.id_CPF_usuario
inner join tbl_servico as S on U.tbl_servico_id_servico = S.id_servico
inner join tbl_vaga as V on U.tbl_vaga_id_vaga = V.id_vaga
inner join tbl_veiculos as R on U.tbl_token_id_token = R.tbl_token_id_token where datediff(hour, timestamp_final_uso, CURRENT_TIMESTAMP) <= 24

Select *, datediff(hour, timestamp_final_uso, CURRENT_TIMESTAMP) from tbl_uso where datediff(hour, timestamp_final_uso, CURRENT_TIMESTAMP) <= 300


Select * from tbl_uso where timestamp_final_uso is null

insert tbl_uso (timestamp_inicio_uso, tbl_vaga_id_vaga, tbl_token_id_token,tbl_usuario_id_CPF_usuario, tbl_servico_id_servico, timestamp_final_uso ) values (CURRENT_TIMESTAMP,2, 3, '00000001234', 6, null)


Select timestamp_inicio_uso, timestamp_final_uso, (DATEDIFF(hour, timestamp_inicio_uso, timestamp_final_uso) * valor_servico_uso) from tbl_uso 


select count(*) as permissao from tbl_funcionario_est where id_func=19041996 and permissao = 0

