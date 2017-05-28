create proc PhieuXuat_getAll as
begin
	select * from Phieu_Xuat
end

create proc chiTietPhieuXuat_findOne (@mapx int) as
begin
	select * from Chi_Tiet_Phieu_Xuat where MA_PX = @mapx
end

create proc PhieuXuat_insert (@ngayXuat date, @lyDo nvarchar(200), @maKho int, @maKH int) as
begin 
	insert into Phieu_Xuat(NGAY_XUAT, LY_DO, MA_KHO, MA_KH)
				values (@ngayXuat, @lyDo, @maKho, @maKH)
end

create proc PhieuXuat_edit (@maPX int, @ngayXuat date, @lyDo nvarchar(200), @maKho int, @maKH int) as
begin 
	update Phieu_Xuat
	set MA_KHO = @maKho, MA_KH = @maKH, NGAY_XUAT = @ngayXuat, LY_DO = @lyDo
	where MA_PX = @maPX
end

create proc ChiTietPhieuXuat_add (@maPX int, @maHang int, @soLuong int, @donGia int) as
begin
	insert into Chi_Tiet_Phieu_Xuat
	values (@maPX, @maHang, @soLuong, @donGia)
end

create proc ChiTietPhieuXuat_edit (@maPX int, @maHang int, @soLuong int, @donGia int) as
begin
	update Chi_Tiet_Phieu_Xuat
	set SL_YEU_CAU = @soLuong, DON_GIA = @donGia
	where MA_PX = @maPX and MA_HANG = @maHang
end

create proc PhieuXuat_delete (@maPX int) as
begin
	update Chi_Tiet_Vat_Tu 
	set MA_PX = null where MA_PHIEU_XUAT = @maPX

	delete from Chi_Tiet_Phieu_Xuat
	where MA_PX = @maPX

	delete from Phieu_Xuat 
	where MA_PX = @maPX
end

create proc ChiTietPhieuXuat_delete (@mahang int) as
begin
	delete from Chi_Tiet_Phieu_Xuat
	where MA_HANG = @mahang
end
 /////////////////////////////////////////////////////////////////////////

 create proc PhieuNhap_getAll as
 begin
	select * from Phieu_Nhap
 end

create proc chiTietPhieuNhap_find(@mapn int) as
begin
select * from Chi_Tiet_Phieu_Nhap where MA_PN = @mapn
end

create proc PhieuNhap_insert(@ngayNhap date, @maNCC int, @maKho int) as 
begin
	insert into Phieu_Nhap(NGAY_NHAP, MA_NHA_CC, MA_KHO)
	values (@ngayNhap, @maNCC, @maKho)
end

create proc PhieuNhap_edit(@ngayNhap date, @maNCC int, @maKho int, @maPN int) as 
begin
	update Phieu_Nhap
	set NGAY_NHAP = @ngayNhap, MA_NHA_CC = @maNCC, MA_KHO = @maKho
	where MA_PN = @maPN
end

create proc PhieuNhap_delete(@maPN int) as
begin
	delete from Chi_Tiet_Phieu_Nhap where MA_PN = @maPN

	update Chi_Tiet_Vat_Tu set MA_PN = null where MA_PN = @maPN

	delete from Phieu_Nhap where MA_PN = @maPN
end

create proc ChiTietPhieuNhap_insert(@mapn int, @mahang int, @slgia int, @slthuc int, @dongia int) as
begin
	insert into Chi_Tiet_Phieu_Nhap(MA_PN, MA_HANG, SL_THEO_CT, SL_THUC, DON_GIA)
	values (@mapn, @mahang , @slgia , @slthuc , @dongia )
end

create proc ChiTietPhieuNhap_update(@mahang int, @slgia int, @slthuc int, @dongia int, @mapn int) as
begin
	update Chi_Tiet_Phieu_Nhap
	set MA_HANG = @mahang, SL_THEO_CT = @slgia, SL_THUC = @slthuc, DON_GIA = @dongia
	where MA_PN = @mapn
end


create proc ChiTietPhieuNhap_delete( @mapn int) as
begin
	delete from Chi_Tiet_Phieu_Nhap where MA_PN = @mapn
end