-- Script de seed com dados reais de editoras e mangás
-- Executar após a criação das tabelas

USE TrabalhoFinalDb;
GO

-- Limpar dados existentes (se houver)
DELETE FROM Mangas;
DELETE FROM Editoras;
GO

-- Resetar identity
DBCC CHECKIDENT ('Mangas', RESEED, 0);
DBCC CHECKIDENT ('Editoras', RESEED, 0);
GO

-- Inserir Editoras
INSERT INTO Editoras (Nome, Pais, AnoFundacao, Site, DataCriacao) VALUES
('Shueisha', 'Japão', 1925, 'https://www.shueisha.co.jp', GETDATE()),
('Kodansha', 'Japão', 1909, 'https://www.kodansha.co.jp', GETDATE()),
('Shogakukan', 'Japão', 1922, 'https://www.shogakukan.co.jp', GETDATE()),
('Square Enix', 'Japão', 1975, 'https://www.jp.square-enix.com', GETDATE()),
('Hakusensha', 'Japão', 1973, 'https://www.hakusensha.co.jp', GETDATE()),
('Kadokawa', 'Japão', 1945, 'https://www.kadokawa.co.jp', GETDATE()),
('Shonen Gahosha', 'Japão', 1974, 'https://www.shonengahosha.co.jp', GETDATE()),
('Akita Shoten', 'Japão', 1948, 'https://www.akitashoten.co.jp', GETDATE()),
('Media Factory', 'Japão', 1986, 'https://www.mediafactory.jp', GETDATE()),
('Mag Garden', 'Japão', 2001, 'https://www.mag-garden.co.jp', GETDATE()),
('ASCII Media Works', 'Japão', 1992, 'https://asciimediaworks.jp', GETDATE()),
('Houbunsha', 'Japão', 1950, 'https://www.houbunsha.co.jp', GETDATE());
GO

-- Inserir Mangás da Shueisha (ID 1)
INSERT INTO Mangas (Titulo, Autor, Genero, Volumes, AnoPublicacao, EmAndamento, Preco, EditoraId, DataCriacao) VALUES
('One Piece', 'Eiichiro Oda', 'Aventura/Shonen', 107, 1997, 1, 29.90, 1, GETDATE()),
('Naruto', 'Masashi Kishimoto', 'Ação/Shonen', 72, 1999, 0, 24.90, 1, GETDATE()),
('Bleach', 'Tite Kubo', 'Ação/Shonen', 74, 2001, 0, 24.90, 1, GETDATE()),
('Death Note', 'Tsugumi Ohba', 'Suspense/Psicológico', 12, 2003, 0, 19.90, 1, GETDATE()),
('Demon Slayer', 'Koyoharu Gotouge', 'Ação/Shonen', 23, 2016, 0, 22.90, 1, GETDATE()),
('My Hero Academia', 'Kohei Horikoshi', 'Ação/Shonen', 39, 2014, 1, 26.90, 1, GETDATE()),
('Jujutsu Kaisen', 'Gege Akutami', 'Ação/Shonen', 24, 2018, 1, 27.90, 1, GETDATE()),
('Hunter x Hunter', 'Yoshihiro Togashi', 'Aventura/Shonen', 37, 1998, 1, 28.90, 1, GETDATE());
GO

-- Inserir Mangás da Kodansha (ID 2)
INSERT INTO Mangas (Titulo, Autor, Genero, Volumes, AnoPublicacao, EmAndamento, Preco, EditoraId, DataCriacao) VALUES
('Attack on Titan', 'Hajime Isayama', 'Ação/Drama', 34, 2009, 0, 25.90, 2, GETDATE()),
('Fairy Tail', 'Hiro Mashima', 'Aventura/Fantasia', 63, 2006, 0, 23.90, 2, GETDATE()),
('Tokyo Revengers', 'Ken Wakui', 'Ação/Drama', 31, 2017, 0, 24.90, 2, GETDATE()),
('Fire Force', 'Atsushi Ohkubo', 'Ação/Shonen', 34, 2015, 0, 24.90, 2, GETDATE()),
('The Seven Deadly Sins', 'Nakaba Suzuki', 'Aventura/Fantasia', 41, 2012, 0, 23.90, 2, GETDATE()),
('Vinland Saga', 'Makoto Yukimura', 'Ação/Histórico', 27, 2005, 1, 32.90, 2, GETDATE()),
('Blue Lock', 'Muneyuki Kaneshiro', 'Esporte/Shonen', 26, 2018, 1, 26.90, 2, GETDATE());
GO

-- Inserir Mangás da Shogakukan (ID 3)
INSERT INTO Mangas (Titulo, Autor, Genero, Volumes, AnoPublicacao, EmAndamento, Preco, EditoraId, DataCriacao) VALUES
('Detective Conan', 'Gosho Aoyama', 'Mistério/Shonen', 103, 1994, 1, 27.90, 3, GETDATE()),
('Inuyasha', 'Rumiko Takahashi', 'Aventura/Fantasia', 56, 1996, 0, 22.90, 3, GETDATE()),
('Ranma 1/2', 'Rumiko Takahashi', 'Comédia/Romance', 38, 1987, 0, 21.90, 3, GETDATE()),
('Magi', 'Shinobu Ohtaka', 'Aventura/Fantasia', 37, 2009, 0, 24.90, 3, GETDATE()),
('Zatch Bell', 'Makoto Raiku', 'Aventura/Shonen', 33, 2001, 0, 20.90, 3, GETDATE());
GO

-- Inserir Mangás da Square Enix (ID 4)
INSERT INTO Mangas (Titulo, Autor, Genero, Volumes, AnoPublicacao, EmAndamento, Preco, EditoraId, DataCriacao) VALUES
('Fullmetal Alchemist', 'Hiromu Arakawa', 'Aventura/Shonen', 27, 2001, 0, 26.90, 4, GETDATE()),
('Soul Eater', 'Atsushi Ohkubo', 'Ação/Fantasia', 25, 2004, 0, 23.90, 4, GETDATE()),
('Pandora Hearts', 'Jun Mochizuki', 'Mistério/Fantasia', 24, 2006, 0, 24.90, 4, GETDATE()),
('Blue Exorcist', 'Kazue Kato', 'Ação/Sobrenatural', 29, 2009, 1, 25.90, 4, GETDATE());
GO

-- Inserir Mangás da Hakusensha (ID 5)
INSERT INTO Mangas (Titulo, Autor, Genero, Volumes, AnoPublicacao, EmAndamento, Preco, EditoraId, DataCriacao) VALUES
('Ouran High School Host Club', 'Bisco Hatori', 'Comédia/Romance', 18, 2002, 0, 22.90, 5, GETDATE()),
('Fruits Basket', 'Natsuki Takaya', 'Romance/Drama', 23, 1998, 0, 24.90, 5, GETDATE()),
('Skip Beat!', 'Yoshiki Nakamura', 'Romance/Comédia', 49, 2002, 1, 23.90, 5, GETDATE());
GO

-- Inserir Mangás da Kadokawa (ID 6)
INSERT INTO Mangas (Titulo, Autor, Genero, Volumes, AnoPublicacao, EmAndamento, Preco, EditoraId, DataCriacao) VALUES
('The Melancholy of Haruhi Suzumiya', 'Nagaru Tanigawa', 'Comédia/Ficção Científica', 20, 2004, 0, 21.90, 6, GETDATE()),
('Overlord', 'Kugane Maruyama', 'Ação/Fantasia', 16, 2012, 1, 28.90, 6, GETDATE()),
('Re:Zero', 'Tappei Nagatsuki', 'Drama/Fantasia', 11, 2014, 1, 27.90, 6, GETDATE());
GO

-- Inserir Mangás da Shonen Gahosha (ID 7)
INSERT INTO Mangas (Titulo, Autor, Genero, Volumes, AnoPublicacao, EmAndamento, Preco, EditoraId, DataCriacao) VALUES
('Berserk', 'Kentaro Miura', 'Ação/Fantasia Sombria', 41, 1989, 1, 35.90, 7, GETDATE()),
('Hellsing', 'Kouta Hirano', 'Ação/Horror', 10, 1997, 0, 24.90, 7, GETDATE()),
('Drifters', 'Kouta Hirano', 'Ação/Fantasia', 6, 2009, 1, 29.90, 7, GETDATE());
GO

-- Inserir Mangás da Akita Shoten (ID 8)
INSERT INTO Mangas (Titulo, Autor, Genero, Volumes, AnoPublicacao, EmAndamento, Preco, EditoraId, DataCriacao) VALUES
('Grappler Baki', 'Keisuke Itagaki', 'Ação/Esporte', 42, 1991, 0, 22.90, 8, GETDATE()),
('Hikaru no Go', 'Yumi Hotta', 'Esporte/Drama', 23, 1998, 0, 21.90, 8, GETDATE());
GO

-- Inserir Mangás da Media Factory (ID 9)
INSERT INTO Mangas (Titulo, Autor, Genero, Volumes, AnoPublicacao, EmAndamento, Preco, EditoraId, DataCriacao) VALUES
('The Rising of the Shield Hero', 'Aneko Yusagi', 'Aventura/Fantasia', 22, 2013, 1, 26.90, 9, GETDATE()),
('That Time I Got Reincarnated as a Slime', 'Fuse', 'Aventura/Fantasia', 22, 2013, 1, 27.90, 9, GETDATE());
GO

-- Inserir Mangás da Mag Garden (ID 10)
INSERT INTO Mangas (Titulo, Autor, Genero, Volumes, AnoPublicacao, EmAndamento, Preco, EditoraId, DataCriacao) VALUES
('Black Lagoon', 'Rei Hiroe', 'Ação/Crime', 12, 2002, 1, 28.90, 10, GETDATE()),
('Horimiya', 'HERO', 'Romance/Slice of Life', 16, 2011, 0, 23.90, 10, GETDATE());
GO

-- Inserir Mangás da ASCII Media Works (ID 11)
INSERT INTO Mangas (Titulo, Autor, Genero, Volumes, AnoPublicacao, EmAndamento, Preco, EditoraId, DataCriacao) VALUES
('Sword Art Online', 'Reki Kawahara', 'Ação/Ficção Científica', 26, 2010, 1, 28.90, 11, GETDATE()),
('Accel World', 'Reki Kawahara', 'Ação/Ficção Científica', 11, 2009, 1, 26.90, 11, GETDATE());
GO

-- Inserir Mangás da Houbunsha (ID 12)
INSERT INTO Mangas (Titulo, Autor, Genero, Volumes, AnoPublicacao, EmAndamento, Preco, EditoraId, DataCriacao) VALUES
('K-On!', 'Kakifly', 'Comédia/Slice of Life', 4, 2007, 0, 19.90, 12, GETDATE()),
('New Game!', 'Shoutarou Tokuno', 'Comédia/Slice of Life', 13, 2013, 0, 21.90, 12, GETDATE());
GO

-- Verificar dados inseridos
SELECT 'Total de Editoras:' AS Info, COUNT(*) AS Quantidade FROM Editoras
UNION ALL
SELECT 'Total de Mangás:', COUNT(*) FROM Mangas;
GO

-- Mostrar distribuição de mangás por editora
SELECT 
    e.Nome AS Editora,
    COUNT(m.Id) AS TotalMangas,
    SUM(CASE WHEN m.EmAndamento = 1 THEN 1 ELSE 0 END) AS EmAndamento,
    SUM(CASE WHEN m.EmAndamento = 0 THEN 1 ELSE 0 END) AS Finalizados
FROM Editoras e
LEFT JOIN Mangas m ON e.Id = m.EditoraId
GROUP BY e.Nome
ORDER BY TotalMangas DESC;
GO
