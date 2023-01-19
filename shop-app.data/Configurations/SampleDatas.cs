using shop_app.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_app.data.Configurations
{
    public static class SampleDatas
    {
        public static Customer[] Customers =
        {
            new Customer()
            {
                Id = Guid.NewGuid(),
                UserName="ensarmakas",
                FirstName= "Ensar",
                LastName= "Makas",
                Email="ensar.makas@gmail.com",
                NormalizedUserName="ENSARMAKAS",
                PasswordHash = "1c651e3b7c11bc861774967073b7dd051d3ca68ef3462c16e0f0ec3716938700" // sha256("ensarmakas")
            }
        };
        public static Seller[] Sellers =
        {
            new Seller()
            {
                Id = Guid.NewGuid(),
                UserName = "bataryadunyasi",
                Name = "Batarya Dünyası",
                Email="bataryadunyasi@gmail.com",
                NormalizedUserName="BATARYADUNYASI",
                PasswordHash = "13f8aa151a8bfcb071dd915abce080a19ef198b8298552eedc5ccc5a9d0a3e3e" // sha256("H3B2#g2bFjzMz%^z")
            }
        };
        
        public static Product[] Products =
        {
            new Product() {Id = Guid.NewGuid(), SellerId= Sellers[0].Id, Name = "Sahibinden temiz İphone", Description="Iphone 13, temiz kullanılmış yalnızca ciddi alıcılar", Uri = Guid.NewGuid().ToString(), Price=10000.00M},
            new Product() {Id = Guid.NewGuid(), SellerId= Sellers[0].Id, Name = "Temiz kullanılmış Macbook M1 Air", Description = "Ciddi alıcılar", Uri = Guid.NewGuid().ToString(), Price=20000.00M},
            new Product() {Id = Guid.NewGuid(), SellerId= Sellers[0].Id, Name = "LG nin incecik televizyonu", Description = "Duvara as, tablo diye izle", Uri = Guid.NewGuid().ToString(), Price=100.00M},
            new Product() {Id = Guid.NewGuid(), SellerId= Sellers[0].Id, Name = "Buz Dolabı", Description = "Güzel soğutur, benim cesedi 10 gün sakladı", Uri = Guid.NewGuid().ToString(), Price=100.00M},
            new Product() {Id = Guid.NewGuid(), SellerId= Sellers[0].Id, Name = "Matkap", Description = "Hobi amaçlı matkap", Uri = Guid.NewGuid().ToString(), Price=100.00M}
        };

        public static ProductImage[] ProductImages = new[]
        {
            new ProductImage()
                { Id = Guid.NewGuid(), ProductId = Products[0].Id, AltText = "iphone", FileUri = "front.png" },
            new ProductImage()
                { Id = Guid.NewGuid(), ProductId = Products[1].Id, AltText = "macbook m1", FileUri = "front.png" },
            new ProductImage()
                { Id = Guid.NewGuid(), ProductId = Products[2].Id, AltText = "televizyon", FileUri = "front.png" },
            new ProductImage()
                { Id = Guid.NewGuid(), ProductId = Products[3].Id, AltText = "buz dolabı", FileUri = "front.png" },
            new ProductImage()
                { Id = Guid.NewGuid(), ProductId = Products[4].Id, AltText = "matkap", FileUri = "front.png" }
        };
        public static Category[] Categories = 
        {
            new Category() {Id = Guid.NewGuid(), Name = "Telefon",URI = "telefon"},
            new Category() {Id = Guid.NewGuid(), Name = "Bilgisayar", URI = "bilgisayar"},
            new Category() {Id = Guid.NewGuid(), Name = "TV",URI = "tv"},
            new Category() {Id = Guid.NewGuid(), Name = "Beyaz Eşya",URI = "beyaz-esya"},
            new Category() {Id = Guid.NewGuid(), Name = "Hobi",URI = "hobi"}
        };
        public static ProductCategory[] ProductCategories =
        {
            new ProductCategory() {Id = Guid.NewGuid(), ProductId = Products[0].Id, CategoryId = Categories[0].Id},
            new ProductCategory() {Id = Guid.NewGuid(), ProductId = Products[1].Id, CategoryId = Categories[1].Id},
            new ProductCategory() {Id = Guid.NewGuid(), ProductId = Products[2].Id, CategoryId = Categories[2].Id},
            new ProductCategory() {Id = Guid.NewGuid(), ProductId = Products[3].Id, CategoryId = Categories[3].Id},
            new ProductCategory() {Id = Guid.NewGuid(), ProductId = Products[4].Id, CategoryId = Categories[4].Id},
        };

        public static Role[] Roles =
        {
            new Role { Id = Guid.NewGuid(), Name = "Individual", NormalizedName = "INDIVIDUAL" },
            new Role { Id = Guid.NewGuid(), Name = "Enterprise", NormalizedName = "ENTERPRISE" }
        };
        
        
        public static User[] Users =
        {
            new User()
            {
                Id = Guid.NewGuid(),
                UserName = "bataryadunyasi",
                Name = "Batarya Dünyası",
                Email="bataryadunyasi@gmail.com",
                NormalizedUserName="BATARYADUNYASI",
                PasswordHash = "13f8aa151a8bfcb071dd915abce080a19ef198b8298552eedc5ccc5a9d0a3e3e" // sha256("H3B2#g2bFjzMz%^z")
            }
        };

        public static UserRole[] UserRoles =
        {
            new UserRole() { RoleId = Roles[0].Id, UserId = Users[0].Id }
        };
    }
}
