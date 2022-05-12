using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProductAddEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if(Request.QueryString["ProductId"] != null)
            {
                GetProduct(Convert.ToInt32(Request.QueryString["ProductId"]));
            }
            GetCompanies();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Product product = new Product()
        {
            ProductName = txtProductName.Text,
            ProductPrice = Convert.ToInt32(txtProductPrice.Text),
            ProductQuntity = Convert.ToInt32(txtProductQuntity.Text),
            CompanyID = Convert.ToInt32(ddlCompany.SelectedValue)
        };

        ProductDBEntities productDBEntities = new ProductDBEntities();

        if (Request.QueryString["ProductId"] != null)
        {
            product.Id = Convert.ToInt32(Request.QueryString["ProductId"]);
            productDBEntities.Entry(product).State = System.Data.Entity.EntityState.Modified;
            productDBEntities.SaveChanges();
            Response.Redirect("~/ProductList.aspx", true);
        }
        else
        {
            productDBEntities.Products.Add(product);
            productDBEntities.SaveChanges();
            lblMsg.Text = "Inserted successfullly";
        }
        
    }

    private void GetProduct(int id)
    {
        ProductDBEntities productDBEntities = new ProductDBEntities();
        Product product = productDBEntities.Products.Find(id);
        txtProductName.Text = product.ProductName;
        txtProductPrice.Text = product.ProductPrice.ToString();
        txtProductQuntity.Text = product.ProductQuntity.ToString();
    }

    private void GetCompanies()
    {
        ProductDBEntities productDBEntities = new ProductDBEntities();
        List<Company> companies = productDBEntities.Companies.ToList();
        foreach (Company company in companies)
        {
            ddlCompany.Items.Add(new ListItem() { Value = company.CompanyID.ToString(), Text = company.CompanyName });
        }
    }

}