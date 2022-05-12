using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProductList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetWithJoin();
        }
    }

    private void GetProducts()
    {
        ProductDBEntities productDBEntities = new ProductDBEntities();
        //var products = productDBEntities.Products.ToList();
        List<Product> productList = productDBEntities.Products.ToList();
        gvProduct.DataSource = productList;
        gvProduct.DataBind();
    }

    private void GetWithJoin()
    {
        ProductDBEntities productDBEntities = new ProductDBEntities();

        List<Product> query = (from Product in productDBEntities.Products.ToList()
                    join Company in productDBEntities.Companies.ToList() on Product.CompanyID equals Company.CompanyID
                    select new Product
                    {
                        Id = Product.Id,
                        ProductName = Product.ProductName,
                        ProductPrice = Product.ProductPrice,
                        ProductQuntity = Product.ProductQuntity,
                        Company = Company
                    }).ToList();
        gvProduct.DataSource = query;
        gvProduct.DataBind();
    }


    private void Delete(int id)
    {
        ProductDBEntities productDBEntities = new ProductDBEntities();
        Product product = productDBEntities.Products.Find(id);
        if(product != null)
        {
            productDBEntities.Products.Remove(product);
            productDBEntities.SaveChanges();
            lblMsg.Text = "Product deleted successfully";
            GetProducts();
        }
        else
        {
            lblMsg.Text = "Product Not Found";
        }
    }

    protected void gvProduct_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            if (e.CommandArgument != null)
            {
                Delete(Convert.ToInt32(e.CommandArgument));
            }
        }
    }

    protected void gvProduct_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
}