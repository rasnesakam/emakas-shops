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
        public static User[] Users =
        {
            new User()
            {
                Id = Guid.NewGuid(),
                UserName="ensarmakas",
                Email="ensar.makas@gmail.com",
                NormalizedUserName="ENSARMAKAS",
                PasswordHash = "1c651e3b7c11bc861774967073b7dd051d3ca68ef3462c16e0f0ec3716938700" // sha256("ensarmakas")
            }
        };
        public static Role[] Roles =
        {
            new Role() { Id = Guid.NewGuid(), Name = "Admin", NormalizedName = "ADMIN" }
        };
        public static UserRole[] UserRoles =
        {
            new UserRole(){UserId = Users[0].Id, RoleId = Roles[0].Id},
        };
        public static Product[] Products =
        {
            new Product() {Id = Guid.NewGuid(), Name = "Sahibinden temiz İphone", Description="Iphone 13, temiz kullanılmış yalnızca ciddi alıcılar", ImageUrl="iphone.png", Price=10000.00M},
            new Product(){Id = Guid.NewGuid(), Name = "Temiz kullanılmış Macbook M1 Air", Description = "Ciddi alıcılar", ImageUrl="mbook.png", Price=20000.00M},
            new Product(){Id = Guid.NewGuid(), Name = "LG nin incecik televizyonu", Description = "Duvara as, tablo diye izle", ImageUrl="lgtv.png", Price=100.00M},
            new Product(){Id = Guid.NewGuid(), Name = "Buz Dolabı", Description = "Güzel soğutur, benim cesedi 10 gün sakladı", ImageUrl="arcelik.png", Price=100.00M},
            new Product(){Id = Guid.NewGuid(), Name = "Matkap", Description = "Hobi amaçlı matkap", ImageUrl="matkap.png", Price=100.00M}
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

    }
}
