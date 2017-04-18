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
	set MA_PHIEU_XUAT = null where MA_PHIEU_XUAT = @maPX

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
drop proc ChiTietPhieuXuat_delete