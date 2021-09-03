select * from Tbl_Contatos

INSERT INTO Tbl_Tipos_Contato(Descricao) VALUES('CLIENTE'), ('FABIO'), ('FUNCIONARIOS')

INSERT INTO Tbl_Contatos(Nome, Sobrenome, TipoId, Endereco, Complemento, Bairro, Cidade, DataAniversario, HomePage, Observacao)
VALUES('Magno', 'Bastos Barboza', 3, 'Rua Geraldo Daflon Faria 398', 'Bl 6 Ap 401', 'Vale Verde', 'Governador Valadares', '18/05/1988', NULL, NULL), 
('Napo', 'Junio Coelho', 3, 'Rua das Aroeiras', NULL, 'Grã-Duquesa', 'Governador Valadares', '18/11/1950', NULL, NULL) 