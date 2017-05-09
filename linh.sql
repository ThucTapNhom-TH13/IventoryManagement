create proc NhaCungCap_getAll as
begin
	select * from Nha_Cung_Cap
end

create proc NuocSX_getAll as
begin
	select * from Nuoc_SX
end

create proc NuocSX_insert (@tenNuoc nvarchar(50)) as
begin
	insert into Nuoc_SX(NUOC_SX)
	values (@tenNuoc)
end

create proc NuocSX_edit(@maNuoc int, @tenNuoc nvarchar(50)) as
begin
	update Nuoc_SX
	set NUOC_SX = @tenNuoc
	where MA_NUOC_SX = @maNuoc
end

create proc NuocSX_delete(@maNuoc int) as
begin
	update Nha_Cung_Cap
	set MA_NUOC_SX = null where MA_NUOC_SX = @maNuoc

	delete Nuoc_SX where MA_NUOC_SX = @maNuoc
end 

create proc NhaCungCap_insert (@tenNhaCC nvarchar(50), @diachi nvarchar(50),@dienthoai nvarchar(50), @maNuoc int) as
begin 
	insert into Nha_Cung_Cap(TEN_NHA_CC, DIA_CHI, DIEN_THOAI, MA_NUOC_SX)
	values (@tenNhaCC, @diachi, @dienthoai, @maNuoc)
end

create proc NhaCungCap_update (@maNhaCC int, @tenNhaCC nvarchar(50), @diachi nvarchar(50),@dienthoai nvarchar(50), @maNuoc int) as
begin
	update Nha_Cung_Cap
	set TEN_NHA_CC = @tenNhaCC, DIA_CHI = @diachi, DIEN_THOAI = @dienthoai, MA_NUOC_SX = @maNuoc
	where MA_NHA_CC = @maNhaCC
end