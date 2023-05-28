using System.ComponentModel.DataAnnotations;

namespace BTLNHOM11.Models;
public class sanpham
{
    [Key]
     [Display( Name = "Mã Sản Phẩm")]
    public string masp {get; set;}
     [Display( Name = "Sản Phẩm")]
    public string tensp {get; set;}
     [Display( Name = "Giá ")]
    public string gia {get; set;}
}