# CrMallTesteAvaliacaoApi

CREATE TABLE IF NOT EXISTS Clientes (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome varchar(255) NOT NULL,
    data_de_nascimento DATE NOT NULL,
    sexo varchar(20) NOT NULL,
    cep varchar(9),
    endereco varchar(50),
    numero varchar(10),
    complemento varchar(30),
    bairro varchar(30),
    estado varchar(30),
    cidade varchar(30)
)  ENGINE=INNODB;
