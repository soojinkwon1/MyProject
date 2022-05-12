using System.ComponentModel.DataAnnotations;

namespace MyWebSite.Models
{
    public class ListModel
    {
        public IList<Article> ArticleModel { get; set; }
        public IList<Portfolio> PortfolioModel { get; set; }
        public IList<Experience> ExperienceModel { get; set; }
        public IList<Skill> SkillModel { get; set; }


    }
}