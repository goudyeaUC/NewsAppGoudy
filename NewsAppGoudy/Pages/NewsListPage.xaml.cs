using NewsAppGoudy.Models;
using NewsAppGoudy.Services;

namespace NewsAppGoudy.Pages;

public partial class NewsListPage : ContentPage
{
    public String Category;
    public List<Article> ArticleList;
    public List<Category> CategoryList = new List<Category>()
        {
            new Category(){Name="World", ImageUrl = "world.png"},
            new Category(){Name = "Nation" , ImageUrl="nation.png"},
            new Category(){Name = "Business" , ImageUrl="business.png"},
            new Category(){Name = "Technology" , ImageUrl="technology.png"},
            new Category(){Name = "Entertainment", ImageUrl = "entertainment.png"},
            new Category(){Name = "Sports" , ImageUrl="sports.png"},
            new Category(){Name = "Science", ImageUrl= "science.png"},
            new Category(){Name = "Health", ImageUrl="health.png"},
        };
    public NewsListPage(string category)
    {
        Category = category;
        InitializeComponent();
        GetBreakingNews();
        ArticleList = new List<Article>();
        CvCategories.ItemsSource = CategoryList;
    }
    private async Task GetBreakingNews()
    {
        var apiService = new ApiService();
        var newsResult = await apiService.GetNews(Category);
        foreach (var item in newsResult.Articles)
        {
            ArticleList.Add(item);
        }
        CvNews.ItemsSource = ArticleList;
    }

    private void CategoryButton_Clicked(object sender, EventArgs e)
    {
        var button = (ImageButton)sender;
        Navigation.PushAsync(new NewsListPage(button.ClassId));
    }

}
