namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Info = c.String(),
                        RegDate = c.DateTime(nullable: false),
                        DeletStatus = c.Boolean(nullable: false),
                        ActivityCategory_id = c.Int(),
                        customer_id = c.Int(),
                        User_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.ActivityCategories", t => t.ActivityCategory_id)
                .ForeignKey("dbo.customers", t => t.customer_id)
                .ForeignKey("dbo.Users", t => t.User_id)
                .Index(t => t.ActivityCategory_id)
                .Index(t => t.customer_id)
                .Index(t => t.User_id);
            
            CreateTable(
                "dbo.ActivityCategories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.customers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DeleteStatus = c.Boolean(nullable: false),
                        Phone = c.String(),
                        Regdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        InvoiceNumber = c.String(),
                        RegDate = c.DateTime(nullable: false),
                        IsCheckedOut = c.Boolean(nullable: false),
                        CheckoutDate = c.DateTime(nullable: false),
                        customer_id = c.Int(),
                        User_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.customers", t => t.customer_id)
                .ForeignKey("dbo.Users", t => t.User_id)
                .Index(t => t.customer_id)
                .Index(t => t.User_id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        Stock = c.Int(nullable: false),
                        DeletStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        Pic = c.String(),
                        status = c.Boolean(nullable: false),
                        RegDate = c.DateTime(nullable: false),
                        DeleteStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Reminders",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ReminderInfo = c.String(),
                        RegDate = c.DateTime(nullable: false),
                        ReminderDate = c.DateTime(nullable: false),
                        IsDone = c.Boolean(),
                        DeleteStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ProductInvoices",
                c => new
                    {
                        Product_id = c.Int(nullable: false),
                        Invoice_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_id, t.Invoice_id })
                .ForeignKey("dbo.Products", t => t.Product_id, cascadeDelete: true)
                .ForeignKey("dbo.Invoices", t => t.Invoice_id, cascadeDelete: true)
                .Index(t => t.Product_id)
                .Index(t => t.Invoice_id);
            
            CreateTable(
                "dbo.ReminderUsers",
                c => new
                    {
                        Reminder_id = c.Int(nullable: false),
                        User_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Reminder_id, t.User_id })
                .ForeignKey("dbo.Reminders", t => t.Reminder_id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_id, cascadeDelete: true)
                .Index(t => t.Reminder_id)
                .Index(t => t.User_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReminderUsers", "User_id", "dbo.Users");
            DropForeignKey("dbo.ReminderUsers", "Reminder_id", "dbo.Reminders");
            DropForeignKey("dbo.Invoices", "User_id", "dbo.Users");
            DropForeignKey("dbo.Activities", "User_id", "dbo.Users");
            DropForeignKey("dbo.ProductInvoices", "Invoice_id", "dbo.Invoices");
            DropForeignKey("dbo.ProductInvoices", "Product_id", "dbo.Products");
            DropForeignKey("dbo.Invoices", "customer_id", "dbo.customers");
            DropForeignKey("dbo.Activities", "customer_id", "dbo.customers");
            DropForeignKey("dbo.Activities", "ActivityCategory_id", "dbo.ActivityCategories");
            DropIndex("dbo.ReminderUsers", new[] { "User_id" });
            DropIndex("dbo.ReminderUsers", new[] { "Reminder_id" });
            DropIndex("dbo.ProductInvoices", new[] { "Invoice_id" });
            DropIndex("dbo.ProductInvoices", new[] { "Product_id" });
            DropIndex("dbo.Invoices", new[] { "User_id" });
            DropIndex("dbo.Invoices", new[] { "customer_id" });
            DropIndex("dbo.Activities", new[] { "User_id" });
            DropIndex("dbo.Activities", new[] { "customer_id" });
            DropIndex("dbo.Activities", new[] { "ActivityCategory_id" });
            DropTable("dbo.ReminderUsers");
            DropTable("dbo.ProductInvoices");
            DropTable("dbo.Reminders");
            DropTable("dbo.Users");
            DropTable("dbo.Products");
            DropTable("dbo.Invoices");
            DropTable("dbo.customers");
            DropTable("dbo.ActivityCategories");
            DropTable("dbo.Activities");
        }
    }
}
