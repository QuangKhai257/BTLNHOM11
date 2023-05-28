using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTLNHOM11.Models;
public class nhaphang 

{
    [Key]
    [Display(Name = "ID nhập hàng")]
    public string idnh {get; set;}


    [Display(Name = "Sản phẩm")]
    public string tensp {get; set;}
    [ForeignKey("tensp")]
    public sanpham? sanpham {get; set;}

     [Display(Name = "Nhà cung cấp")]
     public string tenncc {get; set;}
     [ForeignKey("tenncc")]
     public nhacungcap? nhacungcap {get; set;}


    [Display(Name = "Số lượng nhập ")]
    [Phone(ErrorMessage = "Ghi số lượng ")]
    public string soluongnh { get; set; }

    [Display(Name = "Ngày nhập hàng")]
    public DateTime ngaynh { get; set; }

}