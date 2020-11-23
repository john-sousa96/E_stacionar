DROP DATABASE bd_estacionamentos
GO
CREATE DATABASE bd_estacionamentos
GO
USE bd_estacionamentos
GO

CREATE TABLE tbl_usuario (
  id_CPF_usuario VARCHAR(11) NOT NULL,
  nome_usuario VARCHAR(100) NOT NULL,
  ddd_cel VARCHAR(2) NOT NULL,
  cel_usuario VARCHAR(9) NOT NULL,
  email_usuario VARCHAR(100) NOT NULL,
  senha_usuario VARCHAR(50) NOT NULL,
  status_usuario INT NOT NULL DEFAULT 1,
  permissao INT NOT NULL DEFAULT 4,
  idoso_deficiente INT NOT NULL DEFAULT 0,
  PRIMARY KEY(id_CPF_usuario)
)


CREATE TABLE tbl_token (
  id_token NUMERIC(10) NOT NULL IDENTITY,
  status_token int,
  PRIMARY KEY(id_token)
)

CREATE TABLE tbl_empresa (
  id_cnpj_empresa VARCHAR(14) NOT NULL,
  nome_empresa VARCHAR(100) NOT NULL,
  nome_proprietario_empresa VARCHAR(200) NOT NULL,
  ddd_empresa VARCHAR(2) NOT NULL,
  tel_empresa VARCHAR(9) NOT NULL,
  ramal_tel_empresa VARCHAR(10) NULL,
  email_empresa VARCHAR(70) NOT NULL,
  logradouro_empresa_sede VARCHAR(150) NOT NULL,
  numero_logradouro_empresa_sede VARCHAR(10) NOT NULL,
  complemento_empresa_sede VARCHAR(200) NULL,
  cep_empresa_sede VARCHAR(8) NOT NULL,
  bairro_empresa_sede VARCHAR(30) NOT NULL,
  cidade_empresa_sede VARCHAR(100) NOT NULL,
  estado_empresa_sede VARCHAR(2) NOT NULL,
  senha_empresa VARCHAR(50) NOT NULL,
  status_empresa INT NOT NULL DEFAULT 1,
  permissao INT NULL DEFAULT 2,
  PRIMARY KEY(id_cnpj_empresa)
)

CREATE TABLE tbl_equipamento (
  id_equipamento NUMERIC(10) NOT NULL IDENTITY,
  desc_equipamento VARCHAR(50) NULL,
  PRIMARY KEY(id_equipamento)
)

CREATE TABLE tbl_estacionamento (
  id_estacionamento NUMERIC(15) NOT NULL IDENTITY,
  tbl_empresa_id_cnpj_empresa VARCHAR(14) NOT NULL,
  logradouro_est VARCHAR(150) NOT NULL,
  numero_est VARCHAR(10) NOT NULL,
  complemento_est VARCHAR(200) NULL,
  CEP_est VARCHAR(8) NOT NULL,
  bairro_est VARCHAR(30) NOT NULL,
  regiao_est VARCHAR(10) NOT NULL,
  cidade_est VARCHAR(100) NOT NULL,
  estado_est VARCHAR(2) NOT NULL,
  status_est INT NOT NULL DEFAULT 1,
  ddd_tel_est VARCHAR(2) NULL,
  tel_est VARCHAR(9) NULL,
  ramal_est VARCHAR(10) NULL,
  lat_est VARCHAR(30) NOT NULL,
  lng_est VARCHAR(30) NOT NULL,
  PRIMARY KEY(id_estacionamento),
  INDEX tbl_estacionamento_FKIndex1(tbl_empresa_id_cnpj_empresa),
  FOREIGN KEY(tbl_empresa_id_cnpj_empresa)
    REFERENCES tbl_empresa(id_cnpj_empresa)
);

CREATE TABLE tbl_funcionario_est (
  id_func NUMERIC(15) NOT NULL IDENTITY,
  tbl_estacionamento_id_estacionamento NUMERIC(15) NOT NULL,
  nome_completo_func VARCHAR(200) NOT NULL,
  CPF_func VARCHAR(11) NOT NULL,
  cargo_func VARCHAR(20) NOT NULL,
  senha_func VARCHAR(50) NOT NULL,
  status_func INT NOT NULL DEFAULT 1,
  permissao INT NOT NULL DEFAULT 3,
  PRIMARY KEY(id_func),
  INDEX tbl_funcionario_est_FKIndex1(tbl_estacionamento_id_estacionamento),
  FOREIGN KEY(tbl_estacionamento_id_estacionamento)
    REFERENCES tbl_estacionamento(id_estacionamento)
);

CREATE TABLE tbl_veiculos (
  id_placa_veiculo VARCHAR(7) NOT NULL,
  tbl_token_id_token NUMERIC(10) NULL,
  cidade_veiculo VARCHAR(100) NULL,
  estado_veiculo VARCHAR(2) NULL,
  nome_prop_veiculo VARCHAR(150) NOT NULL,
  marca_veiculo VARCHAR(30) NOT NULL,
  modelo_veiculo VARCHAR(20) NOT NULL,
  cor_veiculo VARCHAR(20) NOT NULL,
  seguro_veiculo INT NOT NULL DEFAULT 0,
  PRIMARY KEY(id_placa_veiculo),
  INDEX tbl_veiculos_FKIndex1(tbl_token_id_token),
  
  FOREIGN KEY(tbl_token_id_token)
    REFERENCES tbl_token(id_token),
);

CREATE TABLE tbl_user_veiculo (
	id_CPF_usuario VARCHAR(11) NOT NULL,
	id_placa_veiculo VARCHAR(7) NOT NULL,

	FOREIGN KEY(id_CPF_usuario)
    REFERENCES tbl_usuario(id_CPF_usuario),

	FOREIGN KEY(id_placa_veiculo)
    REFERENCES tbl_veiculos(id_placa_veiculo),
);

CREATE TABLE tbl_vaga (
  id_vaga NUMERIC(10) NOT NULL IDENTITY,
  tbl_equipamento_id_equipamento NUMERIC(10) NOT NULL,
  tbl_estacionamento_id_estacionamento NUMERIC(15) NOT NULL,
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
  id_servico NUMERIC(10) NOT NULL IDENTITY,
  tbl_estacionamento_id_estacionamento NUMERIC(15) NOT NULL,
  desc_servico VARCHAR(60) NOT NULL,
  valor_servico DECIMAL NOT NULL,
  status_2 INT NOT NULL DEFAULT 1,
  PRIMARY KEY(id_servico),
  INDEX tbl_servico_FKIndex1(tbl_estacionamento_id_estacionamento),
  FOREIGN KEY(tbl_estacionamento_id_estacionamento)
    REFERENCES tbl_estacionamento(id_estacionamento)
);

CREATE TABLE tbl_reservas (
  id_reserva NUMERIC(20) NOT NULL IDENTITY,
  tbl_vaga_id_vaga NUMERIC(10) NOT NULL,
  tbl_token_id_token NUMERIC(10) NULL,
  tbl_usuario_id_CPF_usuario VARCHAR(11) NOT NULL,
  tbl_servico_id_servico NUMERIC(10) NOT NULL,
  timestamp_inicio_reserva DATETIME NOT NULL,
  timestamp_final_reserva DATETIME NOT NULL,
  valor_servico_reserva DECIMAL(6,2) NULL,
  PRIMARY KEY(id_reserva),
  INDEX tbl_reservas_FKIndex1(tbl_servico_id_servico),
  INDEX tbl_reservas_FKIndex2(tbl_usuario_id_CPF_usuario),
  INDEX tbl_reservas_FKIndex3(tbl_token_id_token),
  INDEX tbl_reservas_FKIndex4(tbl_vaga_id_vaga),
  FOREIGN KEY(tbl_servico_id_servico)
    REFERENCES tbl_servico(id_servico),
  FOREIGN KEY(tbl_usuario_id_CPF_usuario)
    REFERENCES tbl_usuario(id_CPF_usuario),
  FOREIGN KEY(tbl_token_id_token)
    REFERENCES tbl_token(id_token),
  FOREIGN KEY(tbl_vaga_id_vaga)
    REFERENCES tbl_vaga(id_vaga)
);

CREATE TABLE tbl_uso (
  id_nota_fiscal_uso NUMERIC(20) NOT NULL IDENTITY,
  tbl_vaga_id_vaga NUMERIC(10) NULL,
  id_placa_veiculo VARCHAR(7) NULL,
  tbl_usuario_id_CPF_usuario VARCHAR(11) NULL,
  tbl_servico_id_servico NUMERIC(10) NOT NULL,
  timestamp_final_uso DATETIME NULL,
  timestamp_inicio_uso DATETIME NULL,
  valor_servico_uso DECIMAL(6,2) NULL,
  PRIMARY KEY(id_nota_fiscal_uso),
  INDEX tbl_uso_FKIndex1(tbl_usuario_id_CPF_usuario),
  INDEX tbl_uso_FKIndex3(tbl_servico_id_servico),
  INDEX tbl_uso_FKIndex4(id_placa_veiculo),
  INDEX tbl_uso_FKIndex5(tbl_vaga_id_vaga),
  FOREIGN KEY(tbl_usuario_id_CPF_usuario)
    REFERENCES tbl_usuario(id_CPF_usuario),
  FOREIGN KEY(tbl_servico_id_servico)
    REFERENCES tbl_servico(id_servico),
  FOREIGN KEY(id_placa_veiculo)
    REFERENCES tbl_veiculos(id_placa_veiculo),
     FOREIGN KEY(tbl_vaga_id_vaga)
    REFERENCES tbl_vaga(id_vaga)
);




INSERT INTO tbl_empresa VALUES
('00000000001234','Empresa de estacionamento teste 1', 'José da Silva', '11','12345678', '002', 'empresateste1@email.com', 'Avenida das sedes', '1234A', 'sala 20, 10º andar', '00021668', 'Centro', 'São Paulo', 'SP', 'SenhaTeste2020*', '1','2' ),
('00000000001235','Empresa de estacionamento teste 2', 'Maria dos Santos', '21','12347895', '003', 'empresateste2@email.com', 'Rua dos testes', '5678', 'sala 10, 2º andar', '00026756', 'Centro', 'Rio de Janeiro', 'RJ', 'SenhaTeste2020*', '1','2' )

INSERT INTO tbl_equipamento (desc_equipamento) VALUES
('controle de vagas'),
('controle de vagas'),
('controle de vagas'),
('controle de vagas'),
('controle de vagas'),
('controle de vagas'), 
('controle de vagas'),
('controle de vagas'),
('controle de vagas'),
('controle de vagas'),
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


SET IDENTITY_INSERT tbl_estacionamento ON

INSERT INTO tbl_estacionamento (id_estacionamento,tbl_empresa_id_cnpj_empresa, logradouro_est, numero_est,complemento_est, CEP_est, bairro_est, regiao_est, cidade_est, estado_est, status_est, ddd_tel_est, tel_est, ramal_est, lat_est, lng_est) VALUES



(14567791234567, '00000000001234', 'Rua teste de rua', '123', 'entrada pelos fundos da empresa X', '02231987', 'Sé', 'centro', 'São Paulo', 'SP', 1, '11', '32145678', '32', '', ''),
(34567891234568, '00000000001234', 'Rua teste de rua 2', '124', 'entrada pelos fundos da empresa X', '02231945', 'Pinheiros', 'Oeste ', 'São Paulo', 'SP', 1, '11', '32145677', '32', '', ''),
(34567891234569, '00000000001234', 'Rua teste de rua 3', '123', 'entrada pelos fundos da empresa X', '02219687', 'Grajaú', 'Sul', 'São Paulo', 'SP', 1, '11', '32145678', '32', '', ''),
(34567891234570, '00000000001234', 'Rua teste de rua 4', '123', 'entrada pelos fundos da empresa X', '02231756', 'Tatuapé', 'Leste', 'São Paulo', 'SP', 1, '11', '32145657', '32', '', ''),
(34567891234571, '00000000001234', 'Rua teste de rua 5', '123', 'entrada pelos fundos da empresa X', '02231578', 'Santana', 'Norte', 'São Paulo', 'SP', 1, '11', '32145658', '32', '', ''),
(34567891234502, '00000000001235', 'Avenida Atlântica ', '123', 'entrada pelos fundos da empresa X', '02231945', 'Copacabana', 'Sul', 'Rio de Janeiro', 'RJ', 1, '21', '45145678', '02', '', ''),
(34567891234503, '00000000001235', 'Avenida X ', '123', 'entrada pelos fundos da empresa X', '02234545', 'Glória', 'Centro', 'Rio de Janeiro', 'RJ', 1, '21', '45145678', '12', '', ''),
(34567891234504, '00000000001235', 'Travessa Y ', '123', 'entrada pelos fundos da empresa X', '02248945', 'Maré', ' Norte', 'Rio de Janeiro', 'RJ', 1, '21', '45145878', '01', '', ''),
(34567891234505, '00000000001235', 'Rodovia da Barra ', '123', 'entrada pelos fundos da empresa X', '02231945', 'Barra da Tijuca', 'Oeste', 'Rio de Janeiro', 'RJ', 1, '21', '45149678', '02', '', '')


INSERT INTO tbl_funcionario_est (tbl_estacionamento_id_estacionamento, nome_completo_func, CPF_func, cargo_func,senha_func) VALUES

(14567791234567, 'José Souza', '213546789', 'Caixa', 'CaIxa123*'),
(34567891234568, 'Lucas Silva', '21354489', 'Caixa', 'CaIxa123*'),
(34567891234569, 'Maria Antônia', '213541234', 'Caixa', 'CaIxa123*'),
(34567891234570, 'Carlos José', '2135461234', 'Caixa', 'CaIxa123*'), 
(34567891234571, 'Maria José', '2135461234', 'Caixa', 'CaIxa123*'), 
(34567891234502, 'William da Silva', '21354671234', 'Caixa', 'CaIxa123*'),
(34567891234503, 'Claúdio', '21354968', 'Caixa', 'CaIxa123*'),
(34567891234504, 'Clóvis', '213547894', 'Caixa', 'CaIxa123*'),
(34567891234505, 'Ronaldo', '213546789', 'Caixa', 'CaIxa123*'), 
(14567791234567, 'Enzo', '213542345', 'Caixa', 'CaIxa123*')

--SET IDENTITY_INSERT tbl_funcionario_est ON
--go

/*INSERT INTO tbl_funcionario_est (id_func, tbl_estacionamento_id_estacionamento, nome_completo_func, CPF_func, cargo_func,senha_func, permissao) VALUES

(19041996, 14567791234567,'Adminstrador', '33344466699', 'Administrador', '*Estacionar2020*',0)

go
*/
INSERT INTO tbl_token (status_token) VALUES
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

INSERT INTO tbl_servico (tbl_estacionamento_id_estacionamento, desc_servico, valor_servico) VALUES
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


INSERT INTO tbl_usuario (id_CPF_usuario, nome_usuario, ddd_cel, cel_usuario, email_usuario, senha_usuario, status_usuario) VALUES

('00000001234', 'Usuário teste', 11, 97777568, 'usuario@mail.com', 'senhausuario', 1),
('00000001235', 'Usuário teste 2', 21, 97777575, 'usuario2@mail.com', 'senhausuario', 1),
('00000001236', 'Usuário teste 3', 11, 97777568, 'usuario3@mail.com', 'senhausuario', 1),
('00000001237', 'Usuário teste 4', 21, 97777575, 'usuario4@mail.com', 'senhausuario', 1)



INSERT INTO tbl_veiculos (id_placa_veiculo, tbl_token_id_token, nome_prop_veiculo, cidade_veiculo, estado_veiculo, marca_veiculo, modelo_veiculo, cor_veiculo, seguro_veiculo) VALUES
('AAA1234', 1, 'Maria de Souza', 'São Paulo', 'SP', 'Citroen', 'C3', 'vermelho', 1),  
('BBB4321', 2, 'José dos Santos', 'Rio de Janeiro', 'RJ', 'Fiat', 'uno', 'vermelho', 1),
('ABC1234', 3, 'João da Silva', 'São Paulo', 'SP', 'Ford', 'ka', 'Laranja', 1),  
('DEF4321', 4, 'Luís Pereira', 'Rio de Janeiro', 'RJ', 'Toyota', 'Yarris', 'vermelho', 1)


INSERT INTO tbl_vaga (tbl_equipamento_id_equipamento, tbl_estacionamento_id_estacionamento, local_vaga, status_vaga) VALUES 

(2, 14567791234567, 'B1', 1),
(3, 14567791234567, 'C2', 1),
(4, 14567791234567, 'A1', 1),
(5, 34567891234568, 'A1', 1),
(6, 34567891234568, 'B2', 1),
(7, 34567891234568, 'C3', 1),
(8, 34567891234569, 'A1', 1),
(9, 34567891234569, 'B2', 1),
(10, 34567891234569, 'C3', 1),
(11, 34567891234502, 'A1', 1),
(12, 14567791234567, 'D1', 1),
(13, 14567791234567, 'E1', 1),
(14, 14567791234567, 'F1', 1),
(15, 14567791234567, 'G1', 1),
(16, 14567791234567, 'H1', 1)

INSERT INTO tbl_uso (tbl_vaga_id_vaga, id_placa_veiculo, tbl_usuario_id_CPF_usuario, tbl_servico_id_servico, timestamp_inicio_uso, timestamp_final_uso, valor_servico_uso) VALUES
(2, 'AAA1234', '00000001234',1, '2020-11-25 10:43:59.953', '2020-11-25 18:43:59.953', 10)
(3, 'BBB4321', '00000001235',1, '2020-11-25 10:43:59.953', '2020-11-25 18:43:59.953', 10)
(4, 'ABC1234', '00000001236',1, '2020-12-04 10:43:59.953', '2020-12-04 18:43:59.953', 10)
(5, 'DEF4321', '00000001237',1, '2020-12-04 10:43:59.953', '2020-12-04 18:43:59.953', 10)

INSERT INTO tbl_reservas (tbl_vaga_id_vaga, tbl_token_id_token, tbl_usuario_id_CPF_usuario, tbl_servico_id_servico, timestamp_inicio_reserva, timestamp_final_reserva, valor_servico_reserva) VALUES 


(2, 1, '00000001234',1, '2020-11-25 21:43:59.953', '2020-11-25 23:43:59.953', 10),
(2, 1, '00000001234',1, '2020-12-04 21:43:59.953', '2020-12-04 23:43:59.953', 10)

GO

USE bd_estacionamentos
GO




/*
			--Select os veículos em uso
			Select U.id_nota_fiscal_uso, U.valor_servico_uso, U.timestamp_inicio_uso, U.timestamp_final_uso,
				(DATEDIFF(MINUTE, U.timestamp_inicio_uso, CURRENT_TIMESTAMP) * (U.valor_servico_uso/60)) as total, 
				C.nome_usuario,	S.desc_servico,v.local_vaga, u.id_placa_veiculo
					from tbl_uso as U
						full join tbl_usuario as C on U.tbl_usuario_id_CPF_usuario = C.id_CPF_usuario
						inner join tbl_servico as S on U.tbl_servico_id_servico = S.id_servico
						inner join tbl_vaga as V on U.tbl_vaga_id_vaga = V.id_vaga 
							where timestamp_final_uso is null
*/


/*
				-- Select os veículos que usaram o estacionamento nas últimas 24h
                Select, U.id_nota_fiscal_uso, U.valor_servico_uso, U.timestamp_inicio_uso, U.timestamp_final_uso, 
					(DATEDIFF(MINUTE, U.timestamp_inicio_uso, CURRENT_TIMESTAMP) * (U.valor_servico_uso/60)) as total, 
					C.nome_usuario, S.desc_servico,v.local_vaga, U.id_placa_veiculo 
						from tbl_uso as U 
							inner join tbl_usuario as C on U.tbl_usuario_id_CPF_usuario = C.id_CPF_usuario
							inner join tbl_servico as S on U.tbl_servico_id_servico = S.id_servico 
							inner join tbl_vaga as V on U.tbl_vaga_id_vaga = V.id_vaga 
								where (datediff(hour, timestamp_final_uso, getdate()) >= 0) and  (datediff(hour, timestamp_final_uso, getdate()) <= 24)

*/

/*
				-- Select veículo
				select id_placa_veiculo, cidade_veiculo, estado_veiculo, nome_prop_veiculo, marca_veiculo, modelo_veiculo, cor_veiculo from tbl_veiculos where id_placa_veiculo = '' 

*/

/*
		-- código para preencher o grid de controle manual
		Select V.local_vaga,
			iif(U.timestamp_final_uso is not null,null,U.id_placa_veiculo) as id_placa_veiculo,
			V.status_vaga, 
			iif(U.timestamp_final_uso is not null,null,U.id_nota_fiscal_uso) as id_nota_fiscal_uso,
			iif(U.timestamp_final_uso is not null,null,U.timestamp_inicio_uso) as timestamp_inicio_uso,
			iif(U.timestamp_final_uso is not null,null,S.desc_servico) as desc_servico 
				from tbl_uso as U
					right join tbl_vaga as V on U.tbl_vaga_id_vaga = V.id_vaga 
					left join tbl_servico as S on U.tbl_servico_id_servico = S.id_servico 
					join tbl_funcionario_est as F on V.tbl_estacionamento_id_estacionamento = F.tbl_estacionamento_id_estacionamento 
						and F.id_func = 1 
							order by local_vaga

*/

/*

			-- Código para carregar as vagas
			Select Distinct (V.local_vaga), V.status_vaga
				from tbl_vaga as V 
					left join tbl_funcionario_est as F on V.tbl_estacionamento_id_estacionamento = F.tbl_estacionamento_id_estacionamento 
					left join tbl_uso as U on U.tbl_vaga_id_vaga = V.id_vaga 
						where F.id_func = 1  and V.status_vaga = 0 
							order by V.local_vaga asc
*/


/*
	-- Código para preencher o ComboBox de Vagas
	Select Distinct(V.local_vaga) 
		from tbl_vaga as V 
			left join tbl_funcionario_est as F on V.tbl_estacionamento_id_estacionamento = F.tbl_estacionamento_id_estacionamento 
			left join tbl_uso as U on U.tbl_vaga_id_vaga = V.id_vaga 
				where F.id_func = 1
*/

/*
		-- Código para preencher comboBox de serviços
		Select Distinct(S.desc_servico) 
			from tbl_Servico as S 
				left join tbl_funcionario_est as F on S.tbl_estacionamento_id_estacionamento = F.tbl_estacionamento_id_estacionamento  
					where F.id_func = 1

*/

 

	



		-- procedure para inserir novo usuário
			create procedure usp_inserir_manualmente
			@id_func numeric(15), @vaga varchar(10), @placa varchar(8),@servico varchar(100), @inicio datetime
		As
			Declare @id_vaga numeric(10) 
			Select @id_vaga = V.id_vaga from tbl_vaga as V 
			inner join tbl_funcionario_est as F on V.tbl_estacionamento_id_estacionamento = F.tbl_estacionamento_id_estacionamento 
			where local_vaga = @vaga and F.id_func = @id_func 
			
			Declare @id_servico numeric(10)
			Select @id_servico = S.id_servico from tbl_servico as S 
			inner join tbl_funcionario_est as F on S.tbl_estacionamento_id_estacionamento = F.tbl_estacionamento_id_estacionamento 
			where S.desc_servico like @servico and F.id_func = @id_func
			
			Declare @valor decimal(18,0)
			Select @valor = valor_servico from tbl_servico where id_servico = @id_servico
			

			insert tbl_uso (tbl_vaga_id_vaga, id_placa_veiculo, tbl_servico_id_servico, timestamp_inicio_uso, valor_servico_uso) VALUES
			(@id_vaga,@placa,@id_servico,@inicio, @valor)
			update tbl_vaga set status_vaga = 1 where id_vaga = @id_vaga
			go
			

			
		
			-- Procedure para botão corrigir e finalizar o uso do cliente
				create procedure usp_corrigir
				@id_func numeric(15), @notaFiscal numeric(20), @vaga varchar(10) , @placa varchar(8),@servico varchar(100), @inicio datetime, @final datetime
				As
				Declare @id_vaga numeric(10) 
				Select @id_vaga = V.id_vaga from tbl_vaga as V inner join tbl_uso as U on V.id_vaga = U.tbl_vaga_id_vaga where  U.id_nota_fiscal_uso = @notaFiscal
				
				Declare @nova_vaga numeric(10) 
				
				Select @nova_vaga  = V.id_vaga from tbl_vaga as V 
				inner join tbl_funcionario_est as F on V.tbl_estacionamento_id_estacionamento = F.tbl_estacionamento_id_estacionamento where local_vaga = @vaga and F.id_func = @id_func 
				
				Declare @id_servico numeric(10)
				Select @id_servico = S.id_servico from tbl_servico as S
				inner join tbl_funcionario_est as F on S.tbl_estacionamento_id_estacionamento = F.tbl_estacionamento_id_estacionamento
				where S.desc_servico like @servico and F.id_func = @id_func
				
				update tbl_uso set tbl_vaga_id_vaga = @nova_vaga, id_placa_veiculo = @placa, tbl_servico_id_servico = @id_servico, timestamp_inicio_uso = @inicio, timestamp_final_uso = @final 
				where id_nota_fiscal_uso = @notaFiscal
				if @id_vaga <> @nova_vaga
					begin 
						update tbl_vaga set status_vaga = 0 where id_vaga = @id_vaga
						update tbl_vaga set status_vaga = 1 where id_vaga = @nova_vaga
					end
				go

				-- procedure para o botão corrigir SEM O HORARIO FINAL
				
				create procedure usp_corrigir_parcialmente
				@id_func numeric(15), @notaFiscal numeric(20), @vaga varchar(10) , @placa varchar(8),@servico varchar(100), @inicio datetime
				As
				Declare @id_vaga numeric(10) 
				Select @id_vaga = V.id_vaga from tbl_vaga as V inner join tbl_uso as U on V.id_vaga = U.tbl_vaga_id_vaga where  U.id_nota_fiscal_uso = @notaFiscal
				
				Declare @nova_vaga numeric(10) 
				
				Select @nova_vaga  = V.id_vaga from tbl_vaga as V 
				inner join tbl_funcionario_est as F on V.tbl_estacionamento_id_estacionamento = F.tbl_estacionamento_id_estacionamento 
				where local_vaga = @vaga and F.id_func = @id_func 

				Declare @id_servico numeric(10)
				Select @id_servico = S.id_servico from tbl_servico as S
				inner join tbl_funcionario_est as F on S.tbl_estacionamento_id_estacionamento = F.tbl_estacionamento_id_estacionamento
				where S.desc_servico like @servico and F.id_func = @id_func
				
				update tbl_uso set tbl_vaga_id_vaga = @nova_vaga, id_placa_veiculo = @placa, tbl_servico_id_servico = @id_servico, timestamp_inicio_uso = @inicio 
				where id_nota_fiscal_uso = @notaFiscal
				if @id_vaga <> @nova_vaga
					begin 
						update tbl_vaga set status_vaga = 0 where id_vaga = @id_vaga
						update tbl_vaga set status_vaga = 1 where id_vaga = @nova_vaga
					end
				go


				