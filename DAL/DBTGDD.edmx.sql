
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/24/2023 22:02:05
-- Generated from EDMX file: D:\CSharp\DUANCANHAN\QLTGDD\TGDDSoftWare\DAL\DBTGDD.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DB_QLTGDD];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_tb_BANGCONG_tb_CHINHANH]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tb_BANGCONG] DROP CONSTRAINT [FK_tb_BANGCONG_tb_CHINHANH];
GO
IF OBJECT_ID(N'[dbo].[FK_tb_BANGCONG_tb_NHANVIEN]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tb_BANGCONG] DROP CONSTRAINT [FK_tb_BANGCONG_tb_NHANVIEN];
GO
IF OBJECT_ID(N'[dbo].[FK_tb_BANGCONGCHITIET_tb_BANGCONG]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tb_BANGCONGCHITIET] DROP CONSTRAINT [FK_tb_BANGCONGCHITIET_tb_BANGCONG];
GO
IF OBJECT_ID(N'[dbo].[FK_tb_BCCT_NGAYCONG_tb_BANGCONGCHITIET1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tb_BCCT_NGAYCONG] DROP CONSTRAINT [FK_tb_BCCT_NGAYCONG_tb_BANGCONGCHITIET1];
GO
IF OBJECT_ID(N'[dbo].[FK_tb_BCCT_NGAYCONG_tb_NGAYCONGCHITET]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tb_BCCT_NGAYCONG] DROP CONSTRAINT [FK_tb_BCCT_NGAYCONG_tb_NGAYCONGCHITET];
GO
IF OBJECT_ID(N'[dbo].[FK_tb_DANHSO_tb_CHINHANH]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tb_DANHSO] DROP CONSTRAINT [FK_tb_DANHSO_tb_CHINHANH];
GO
IF OBJECT_ID(N'[dbo].[FK_tb_DANHSO_tb_NHANVIEN]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tb_DANHSO] DROP CONSTRAINT [FK_tb_DANHSO_tb_NHANVIEN];
GO
IF OBJECT_ID(N'[dbo].[FK_tb_DANHSOCHITIET_tb_DANHSO]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tb_DANHSOCHITIET] DROP CONSTRAINT [FK_tb_DANHSOCHITIET_tb_DANHSO];
GO
IF OBJECT_ID(N'[dbo].[FK_tb_DANHSOCHITIET_tb_SANPHAM]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tb_DANHSOCHITIET] DROP CONSTRAINT [FK_tb_DANHSOCHITIET_tb_SANPHAM];
GO
IF OBJECT_ID(N'[dbo].[FK_tb_HOPDONG_tb_NHANVIEN]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tb_HOPDONG] DROP CONSTRAINT [FK_tb_HOPDONG_tb_NHANVIEN];
GO
IF OBJECT_ID(N'[dbo].[FK_tb_NGAYCONGCHITET_tb_LOAICONG]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tb_NGAYCONGCHITET] DROP CONSTRAINT [FK_tb_NGAYCONGCHITET_tb_LOAICONG];
GO
IF OBJECT_ID(N'[dbo].[FK_tb_NHANVIEN_tb_CHINHANH]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tb_NHANVIEN] DROP CONSTRAINT [FK_tb_NHANVIEN_tb_CHINHANH];
GO
IF OBJECT_ID(N'[dbo].[FK_tb_NHANVIEN_tb_CHUCVU]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tb_NHANVIEN] DROP CONSTRAINT [FK_tb_NHANVIEN_tb_CHUCVU];
GO
IF OBJECT_ID(N'[dbo].[FK_tb_NHANVIEN_tb_PHONGBAN]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tb_NHANVIEN] DROP CONSTRAINT [FK_tb_NHANVIEN_tb_PHONGBAN];
GO
IF OBJECT_ID(N'[dbo].[FK_tb_PHUCAP_NHANVIEN_tb_NHANVIEN]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tb_PHUCAP_NHANVIEN] DROP CONSTRAINT [FK_tb_PHUCAP_NHANVIEN_tb_NHANVIEN];
GO
IF OBJECT_ID(N'[dbo].[FK_tb_PHUCAP_NHANVIEN_tb_PHUCAP]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tb_PHUCAP_NHANVIEN] DROP CONSTRAINT [FK_tb_PHUCAP_NHANVIEN_tb_PHUCAP];
GO
IF OBJECT_ID(N'[dbo].[FK_tb_UNGLUONG_tb_NHANVIEN]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tb_UNGLUONG] DROP CONSTRAINT [FK_tb_UNGLUONG_tb_NHANVIEN];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[tb_BANGCONG]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tb_BANGCONG];
GO
IF OBJECT_ID(N'[dbo].[tb_BANGCONGCHITIET]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tb_BANGCONGCHITIET];
GO
IF OBJECT_ID(N'[dbo].[tb_BCCT_NGAYCONG]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tb_BCCT_NGAYCONG];
GO
IF OBJECT_ID(N'[dbo].[tb_CHINHANH]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tb_CHINHANH];
GO
IF OBJECT_ID(N'[dbo].[tb_CHUCVU]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tb_CHUCVU];
GO
IF OBJECT_ID(N'[dbo].[tb_DANHSO]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tb_DANHSO];
GO
IF OBJECT_ID(N'[dbo].[tb_DANHSOCHITIET]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tb_DANHSOCHITIET];
GO
IF OBJECT_ID(N'[dbo].[tb_HOPDONG]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tb_HOPDONG];
GO
IF OBJECT_ID(N'[dbo].[tb_LOAICONG]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tb_LOAICONG];
GO
IF OBJECT_ID(N'[dbo].[tb_NGAYCONGCHITET]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tb_NGAYCONGCHITET];
GO
IF OBJECT_ID(N'[dbo].[tb_NHANVIEN]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tb_NHANVIEN];
GO
IF OBJECT_ID(N'[dbo].[tb_PHONGBAN]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tb_PHONGBAN];
GO
IF OBJECT_ID(N'[dbo].[tb_PHUCAP]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tb_PHUCAP];
GO
IF OBJECT_ID(N'[dbo].[tb_PHUCAP_NHANVIEN]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tb_PHUCAP_NHANVIEN];
GO
IF OBJECT_ID(N'[dbo].[tb_SANPHAM]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tb_SANPHAM];
GO
IF OBJECT_ID(N'[dbo].[tb_UNGLUONG]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tb_UNGLUONG];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'tb_BANGCONG'
CREATE TABLE [dbo].[tb_BANGCONG] (
    [MABC] int  NOT NULL,
    [THANG] int  NULL,
    [NAM] int  NULL,
    [KHOA] bit  NULL,
    [NGAYTINHCONG] datetime  NULL,
    [NGAYCONGTRONGTHANG] float  NULL,
    [MACN] int  NULL,
    [TRANGTHI] bit  NULL,
    [MANV] int  NULL
);
GO

-- Creating table 'tb_BANGCONGCHITIET'
CREATE TABLE [dbo].[tb_BANGCONGCHITIET] (
    [MABCCT] int  NOT NULL,
    [MANGAYCONG] int  NULL,
    [MABC] int  NULL,
    [SONGAYCONG] float  NULL,
    [TONGNGAYCONG] float  NULL
);
GO

-- Creating table 'tb_BCCT_NGAYCONG'
CREATE TABLE [dbo].[tb_BCCT_NGAYCONG] (
    [MABCCT] int  NOT NULL,
    [MANCNV] int  NOT NULL
);
GO

-- Creating table 'tb_CHINHANH'
CREATE TABLE [dbo].[tb_CHINHANH] (
    [MACN] int IDENTITY(1,1) NOT NULL,
    [TENCN] nvarchar(255)  NULL,
    [MAIL] nvarchar(255)  NULL,
    [SDT] nchar(10)  NULL,
    [DIACHI] nvarchar(500)  NULL
);
GO

-- Creating table 'tb_CHUCVU'
CREATE TABLE [dbo].[tb_CHUCVU] (
    [MACV] int IDENTITY(1,1) NOT NULL,
    [TENCV] nvarchar(500)  NULL
);
GO

-- Creating table 'tb_DANHSO'
CREATE TABLE [dbo].[tb_DANHSO] (
    [MADS] nchar(15)  NOT NULL,
    [THANG] int  NULL,
    [NAM] int  NULL,
    [TONGDS] int  NULL,
    [MACN] int  NULL,
    [MANV] int  NULL
);
GO

-- Creating table 'tb_DANHSOCHITIET'
CREATE TABLE [dbo].[tb_DANHSOCHITIET] (
    [MASP] int  NOT NULL,
    [MADS] nchar(15)  NOT NULL,
    [NGAY] datetime  NULL,
    [GHICHU] nvarchar(500)  NULL
);
GO

-- Creating table 'tb_HOPDONG'
CREATE TABLE [dbo].[tb_HOPDONG] (
    [SOHD] char(15)  NOT NULL,
    [NGAYBATDAU] datetime  NULL,
    [NGAYKETTHUC] datetime  NULL,
    [NGAYKY] datetime  NULL,
    [NOIDUNG] nvarchar(max)  NULL,
    [LANKY] int  NULL,
    [THOIGIAN] nvarchar(50)  NULL,
    [HESOLUONG] float  NULL,
    [MANV] int  NULL,
    [MACN] int  NULL
);
GO

-- Creating table 'tb_LOAICONG'
CREATE TABLE [dbo].[tb_LOAICONG] (
    [MALC] int IDENTITY(1,1) NOT NULL,
    [TENLC] nvarchar(500)  NULL,
    [HESO] float  NULL
);
GO

-- Creating table 'tb_NGAYCONGCHITET'
CREATE TABLE [dbo].[tb_NGAYCONGCHITET] (
    [MANCNV] int  NOT NULL,
    [NGAY] int  NULL,
    [THU] nvarchar(50)  NULL,
    [GIOIVAO] nvarchar(50)  NULL,
    [GIOIRA] nvarchar(50)  NULL,
    [KYHIEU] nchar(10)  NULL,
    [GHICHU] nvarchar(500)  NULL,
    [MALC] int  NULL,
    [MANGAYCONGNHANVIEN] int  NOT NULL
);
GO

-- Creating table 'tb_NHANVIEN'
CREATE TABLE [dbo].[tb_NHANVIEN] (
    [MANV] int IDENTITY(1,1) NOT NULL,
    [HOTEN] nvarchar(255)  NULL,
    [GIOITINH] bit  NULL,
    [NGAYSINH] datetime  NULL,
    [DIENTHOAI] nchar(10)  NULL,
    [EMAIL] nvarchar(255)  NULL,
    [HINHANH] varbinary(max)  NULL,
    [CCCD] char(12)  NULL,
    [DIACHI] nvarchar(500)  NULL,
    [MAPB] int  NULL,
    [MACV] int  NULL,
    [MACN] int  NULL
);
GO

-- Creating table 'tb_PHONGBAN'
CREATE TABLE [dbo].[tb_PHONGBAN] (
    [MAPB] int IDENTITY(1,1) NOT NULL,
    [TENPB] nvarchar(500)  NULL,
    [SDT] nchar(10)  NULL,
    [MAIL] nvarchar(255)  NULL,
    [DIACHI] nvarchar(500)  NULL
);
GO

-- Creating table 'tb_PHUCAP'
CREATE TABLE [dbo].[tb_PHUCAP] (
    [MAPC] int IDENTITY(1,1) NOT NULL,
    [TENPHUCAP] nvarchar(500)  NULL,
    [SOTIEN] float  NULL
);
GO

-- Creating table 'tb_PHUCAP_NHANVIEN'
CREATE TABLE [dbo].[tb_PHUCAP_NHANVIEN] (
    [MANV] int  NOT NULL,
    [MAPC] int  NOT NULL,
    [NGAY] datetime  NULL,
    [NOIDUNG] nvarchar(500)  NULL,
    [SOTIEN] float  NULL
);
GO

-- Creating table 'tb_SANPHAM'
CREATE TABLE [dbo].[tb_SANPHAM] (
    [MASP] int IDENTITY(1,1) NOT NULL,
    [TENSP] nvarchar(500)  NULL,
    [GIA] float  NULL
);
GO

-- Creating table 'tb_UNGLUONG'
CREATE TABLE [dbo].[tb_UNGLUONG] (
    [MAUL] char(15)  NOT NULL,
    [NGAY] datetime  NULL,
    [SOTIEN] float  NULL,
    [MANV] int  NULL,
    [GHICHU] nvarchar(500)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [MABC] in table 'tb_BANGCONG'
ALTER TABLE [dbo].[tb_BANGCONG]
ADD CONSTRAINT [PK_tb_BANGCONG]
    PRIMARY KEY CLUSTERED ([MABC] ASC);
GO

-- Creating primary key on [MABCCT] in table 'tb_BANGCONGCHITIET'
ALTER TABLE [dbo].[tb_BANGCONGCHITIET]
ADD CONSTRAINT [PK_tb_BANGCONGCHITIET]
    PRIMARY KEY CLUSTERED ([MABCCT] ASC);
GO

-- Creating primary key on [MABCCT], [MANCNV] in table 'tb_BCCT_NGAYCONG'
ALTER TABLE [dbo].[tb_BCCT_NGAYCONG]
ADD CONSTRAINT [PK_tb_BCCT_NGAYCONG]
    PRIMARY KEY CLUSTERED ([MABCCT], [MANCNV] ASC);
GO

-- Creating primary key on [MACN] in table 'tb_CHINHANH'
ALTER TABLE [dbo].[tb_CHINHANH]
ADD CONSTRAINT [PK_tb_CHINHANH]
    PRIMARY KEY CLUSTERED ([MACN] ASC);
GO

-- Creating primary key on [MACV] in table 'tb_CHUCVU'
ALTER TABLE [dbo].[tb_CHUCVU]
ADD CONSTRAINT [PK_tb_CHUCVU]
    PRIMARY KEY CLUSTERED ([MACV] ASC);
GO

-- Creating primary key on [MADS] in table 'tb_DANHSO'
ALTER TABLE [dbo].[tb_DANHSO]
ADD CONSTRAINT [PK_tb_DANHSO]
    PRIMARY KEY CLUSTERED ([MADS] ASC);
GO

-- Creating primary key on [MASP], [MADS] in table 'tb_DANHSOCHITIET'
ALTER TABLE [dbo].[tb_DANHSOCHITIET]
ADD CONSTRAINT [PK_tb_DANHSOCHITIET]
    PRIMARY KEY CLUSTERED ([MASP], [MADS] ASC);
GO

-- Creating primary key on [SOHD] in table 'tb_HOPDONG'
ALTER TABLE [dbo].[tb_HOPDONG]
ADD CONSTRAINT [PK_tb_HOPDONG]
    PRIMARY KEY CLUSTERED ([SOHD] ASC);
GO

-- Creating primary key on [MALC] in table 'tb_LOAICONG'
ALTER TABLE [dbo].[tb_LOAICONG]
ADD CONSTRAINT [PK_tb_LOAICONG]
    PRIMARY KEY CLUSTERED ([MALC] ASC);
GO

-- Creating primary key on [MANCNV] in table 'tb_NGAYCONGCHITET'
ALTER TABLE [dbo].[tb_NGAYCONGCHITET]
ADD CONSTRAINT [PK_tb_NGAYCONGCHITET]
    PRIMARY KEY CLUSTERED ([MANCNV] ASC);
GO

-- Creating primary key on [MANV] in table 'tb_NHANVIEN'
ALTER TABLE [dbo].[tb_NHANVIEN]
ADD CONSTRAINT [PK_tb_NHANVIEN]
    PRIMARY KEY CLUSTERED ([MANV] ASC);
GO

-- Creating primary key on [MAPB] in table 'tb_PHONGBAN'
ALTER TABLE [dbo].[tb_PHONGBAN]
ADD CONSTRAINT [PK_tb_PHONGBAN]
    PRIMARY KEY CLUSTERED ([MAPB] ASC);
GO

-- Creating primary key on [MAPC] in table 'tb_PHUCAP'
ALTER TABLE [dbo].[tb_PHUCAP]
ADD CONSTRAINT [PK_tb_PHUCAP]
    PRIMARY KEY CLUSTERED ([MAPC] ASC);
GO

-- Creating primary key on [MANV], [MAPC] in table 'tb_PHUCAP_NHANVIEN'
ALTER TABLE [dbo].[tb_PHUCAP_NHANVIEN]
ADD CONSTRAINT [PK_tb_PHUCAP_NHANVIEN]
    PRIMARY KEY CLUSTERED ([MANV], [MAPC] ASC);
GO

-- Creating primary key on [MASP] in table 'tb_SANPHAM'
ALTER TABLE [dbo].[tb_SANPHAM]
ADD CONSTRAINT [PK_tb_SANPHAM]
    PRIMARY KEY CLUSTERED ([MASP] ASC);
GO

-- Creating primary key on [MAUL] in table 'tb_UNGLUONG'
ALTER TABLE [dbo].[tb_UNGLUONG]
ADD CONSTRAINT [PK_tb_UNGLUONG]
    PRIMARY KEY CLUSTERED ([MAUL] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [MACN] in table 'tb_BANGCONG'
ALTER TABLE [dbo].[tb_BANGCONG]
ADD CONSTRAINT [FK_tb_BANGCONG_tb_CHINHANH]
    FOREIGN KEY ([MACN])
    REFERENCES [dbo].[tb_CHINHANH]
        ([MACN])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tb_BANGCONG_tb_CHINHANH'
CREATE INDEX [IX_FK_tb_BANGCONG_tb_CHINHANH]
ON [dbo].[tb_BANGCONG]
    ([MACN]);
GO

-- Creating foreign key on [MANV] in table 'tb_BANGCONG'
ALTER TABLE [dbo].[tb_BANGCONG]
ADD CONSTRAINT [FK_tb_BANGCONG_tb_NHANVIEN]
    FOREIGN KEY ([MANV])
    REFERENCES [dbo].[tb_NHANVIEN]
        ([MANV])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tb_BANGCONG_tb_NHANVIEN'
CREATE INDEX [IX_FK_tb_BANGCONG_tb_NHANVIEN]
ON [dbo].[tb_BANGCONG]
    ([MANV]);
GO

-- Creating foreign key on [MABC] in table 'tb_BANGCONGCHITIET'
ALTER TABLE [dbo].[tb_BANGCONGCHITIET]
ADD CONSTRAINT [FK_tb_BANGCONGCHITIET_tb_BANGCONG]
    FOREIGN KEY ([MABC])
    REFERENCES [dbo].[tb_BANGCONG]
        ([MABC])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tb_BANGCONGCHITIET_tb_BANGCONG'
CREATE INDEX [IX_FK_tb_BANGCONGCHITIET_tb_BANGCONG]
ON [dbo].[tb_BANGCONGCHITIET]
    ([MABC]);
GO

-- Creating foreign key on [MANCNV] in table 'tb_BCCT_NGAYCONG'
ALTER TABLE [dbo].[tb_BCCT_NGAYCONG]
ADD CONSTRAINT [FK_tb_BCCT_NGAYCONG_tb_BANGCONGCHITIET1]
    FOREIGN KEY ([MANCNV])
    REFERENCES [dbo].[tb_BANGCONGCHITIET]
        ([MABCCT])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tb_BCCT_NGAYCONG_tb_BANGCONGCHITIET1'
CREATE INDEX [IX_FK_tb_BCCT_NGAYCONG_tb_BANGCONGCHITIET1]
ON [dbo].[tb_BCCT_NGAYCONG]
    ([MANCNV]);
GO

-- Creating foreign key on [MANCNV] in table 'tb_BCCT_NGAYCONG'
ALTER TABLE [dbo].[tb_BCCT_NGAYCONG]
ADD CONSTRAINT [FK_tb_BCCT_NGAYCONG_tb_NGAYCONGCHITET]
    FOREIGN KEY ([MANCNV])
    REFERENCES [dbo].[tb_NGAYCONGCHITET]
        ([MANCNV])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tb_BCCT_NGAYCONG_tb_NGAYCONGCHITET'
CREATE INDEX [IX_FK_tb_BCCT_NGAYCONG_tb_NGAYCONGCHITET]
ON [dbo].[tb_BCCT_NGAYCONG]
    ([MANCNV]);
GO

-- Creating foreign key on [MACN] in table 'tb_DANHSO'
ALTER TABLE [dbo].[tb_DANHSO]
ADD CONSTRAINT [FK_tb_DANHSO_tb_CHINHANH]
    FOREIGN KEY ([MACN])
    REFERENCES [dbo].[tb_CHINHANH]
        ([MACN])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tb_DANHSO_tb_CHINHANH'
CREATE INDEX [IX_FK_tb_DANHSO_tb_CHINHANH]
ON [dbo].[tb_DANHSO]
    ([MACN]);
GO

-- Creating foreign key on [MACV] in table 'tb_NHANVIEN'
ALTER TABLE [dbo].[tb_NHANVIEN]
ADD CONSTRAINT [FK_tb_NHANVIEN_tb_CHINHANH]
    FOREIGN KEY ([MACV])
    REFERENCES [dbo].[tb_CHINHANH]
        ([MACN])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tb_NHANVIEN_tb_CHINHANH'
CREATE INDEX [IX_FK_tb_NHANVIEN_tb_CHINHANH]
ON [dbo].[tb_NHANVIEN]
    ([MACV]);
GO

-- Creating foreign key on [MACV] in table 'tb_NHANVIEN'
ALTER TABLE [dbo].[tb_NHANVIEN]
ADD CONSTRAINT [FK_tb_NHANVIEN_tb_CHUCVU]
    FOREIGN KEY ([MACV])
    REFERENCES [dbo].[tb_CHUCVU]
        ([MACV])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tb_NHANVIEN_tb_CHUCVU'
CREATE INDEX [IX_FK_tb_NHANVIEN_tb_CHUCVU]
ON [dbo].[tb_NHANVIEN]
    ([MACV]);
GO

-- Creating foreign key on [MANV] in table 'tb_DANHSO'
ALTER TABLE [dbo].[tb_DANHSO]
ADD CONSTRAINT [FK_tb_DANHSO_tb_NHANVIEN]
    FOREIGN KEY ([MANV])
    REFERENCES [dbo].[tb_NHANVIEN]
        ([MANV])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tb_DANHSO_tb_NHANVIEN'
CREATE INDEX [IX_FK_tb_DANHSO_tb_NHANVIEN]
ON [dbo].[tb_DANHSO]
    ([MANV]);
GO

-- Creating foreign key on [MADS] in table 'tb_DANHSOCHITIET'
ALTER TABLE [dbo].[tb_DANHSOCHITIET]
ADD CONSTRAINT [FK_tb_DANHSOCHITIET_tb_DANHSO]
    FOREIGN KEY ([MADS])
    REFERENCES [dbo].[tb_DANHSO]
        ([MADS])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tb_DANHSOCHITIET_tb_DANHSO'
CREATE INDEX [IX_FK_tb_DANHSOCHITIET_tb_DANHSO]
ON [dbo].[tb_DANHSOCHITIET]
    ([MADS]);
GO

-- Creating foreign key on [MASP] in table 'tb_DANHSOCHITIET'
ALTER TABLE [dbo].[tb_DANHSOCHITIET]
ADD CONSTRAINT [FK_tb_DANHSOCHITIET_tb_SANPHAM]
    FOREIGN KEY ([MASP])
    REFERENCES [dbo].[tb_SANPHAM]
        ([MASP])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [MANV] in table 'tb_HOPDONG'
ALTER TABLE [dbo].[tb_HOPDONG]
ADD CONSTRAINT [FK_tb_HOPDONG_tb_NHANVIEN]
    FOREIGN KEY ([MANV])
    REFERENCES [dbo].[tb_NHANVIEN]
        ([MANV])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tb_HOPDONG_tb_NHANVIEN'
CREATE INDEX [IX_FK_tb_HOPDONG_tb_NHANVIEN]
ON [dbo].[tb_HOPDONG]
    ([MANV]);
GO

-- Creating foreign key on [MALC] in table 'tb_NGAYCONGCHITET'
ALTER TABLE [dbo].[tb_NGAYCONGCHITET]
ADD CONSTRAINT [FK_tb_NGAYCONGCHITET_tb_LOAICONG]
    FOREIGN KEY ([MALC])
    REFERENCES [dbo].[tb_LOAICONG]
        ([MALC])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tb_NGAYCONGCHITET_tb_LOAICONG'
CREATE INDEX [IX_FK_tb_NGAYCONGCHITET_tb_LOAICONG]
ON [dbo].[tb_NGAYCONGCHITET]
    ([MALC]);
GO

-- Creating foreign key on [MAPB] in table 'tb_NHANVIEN'
ALTER TABLE [dbo].[tb_NHANVIEN]
ADD CONSTRAINT [FK_tb_NHANVIEN_tb_PHONGBAN]
    FOREIGN KEY ([MAPB])
    REFERENCES [dbo].[tb_PHONGBAN]
        ([MAPB])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tb_NHANVIEN_tb_PHONGBAN'
CREATE INDEX [IX_FK_tb_NHANVIEN_tb_PHONGBAN]
ON [dbo].[tb_NHANVIEN]
    ([MAPB]);
GO

-- Creating foreign key on [MANV] in table 'tb_PHUCAP_NHANVIEN'
ALTER TABLE [dbo].[tb_PHUCAP_NHANVIEN]
ADD CONSTRAINT [FK_tb_PHUCAP_NHANVIEN_tb_NHANVIEN]
    FOREIGN KEY ([MANV])
    REFERENCES [dbo].[tb_NHANVIEN]
        ([MANV])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [MANV] in table 'tb_UNGLUONG'
ALTER TABLE [dbo].[tb_UNGLUONG]
ADD CONSTRAINT [FK_tb_UNGLUONG_tb_NHANVIEN]
    FOREIGN KEY ([MANV])
    REFERENCES [dbo].[tb_NHANVIEN]
        ([MANV])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tb_UNGLUONG_tb_NHANVIEN'
CREATE INDEX [IX_FK_tb_UNGLUONG_tb_NHANVIEN]
ON [dbo].[tb_UNGLUONG]
    ([MANV]);
GO

-- Creating foreign key on [MAPC] in table 'tb_PHUCAP_NHANVIEN'
ALTER TABLE [dbo].[tb_PHUCAP_NHANVIEN]
ADD CONSTRAINT [FK_tb_PHUCAP_NHANVIEN_tb_PHUCAP]
    FOREIGN KEY ([MAPC])
    REFERENCES [dbo].[tb_PHUCAP]
        ([MAPC])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tb_PHUCAP_NHANVIEN_tb_PHUCAP'
CREATE INDEX [IX_FK_tb_PHUCAP_NHANVIEN_tb_PHUCAP]
ON [dbo].[tb_PHUCAP_NHANVIEN]
    ([MAPC]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------