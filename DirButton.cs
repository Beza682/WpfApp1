using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows;

namespace WpfApp1
{
    public class DirButton
    {
        gr691_baoEntities1 db = new gr691_baoEntities1();
        Search Search = new Search();
        public bool Insert(string id, int OrgName, string WorkPhone)
        {
            Regex SpecialSimbols = new Regex("([#]|[=]|[/]|[*]|[@]|[&]|[>]|[<]|[;]|[']|[$]|[№]|[!]|[№]|[;]|[{]|[}]|[[]|[]]|[~])");
            Regex Words = new Regex(@"(\D)");
            MatchCollection matchSpecialSymbol;
            MatchCollection matchWords;
            matchSpecialSymbol = SpecialSimbols.Matches(WorkPhone);
            matchWords = Words.Matches(WorkPhone);
            try
            {
                if (string.IsNullOrWhiteSpace(id) == false)
                {
                    MessageBox.Show("Ошибка в таблице <Search>!\nВы хотели добавить id сами. Он проставляется автоматически.", "My App", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (string.IsNullOrWhiteSpace(WorkPhone) == true)
                {
                    MessageBox.Show("Ошибка в таблице <Search>!\nВы забыли внести данные в поле <name>.", "My App", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (matchSpecialSymbol.Count > 0)
                {
                    MessageBox.Show("Ошибка в таблице <Search>!\nВ названии предмета не допускаются спецсимволы.", "My App", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (matchWords.Count > 0)
                {
                    MessageBox.Show("Ошибка в таблице <Search>!\nВ названии предмета вводятся только кирилица.", "My App", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    Search.OrganizationId = OrgName;
                    Search.WorkPhone = WorkPhone;
                    db.Search.Add(Search);
                    db.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка в таблице <Search>!\nВведите корректные значения.", "My App", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        public bool Delete(string id)
        {
            try
            {
                int num = Convert.ToInt32(id);
                var dRow = db.Search.Where(w => w.Id == num).FirstOrDefault();
                if (dRow == null)
                {
                    MessageBox.Show("Ошибка в таблице <Search>!\nТакого id не существует.", "My App", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    try
                    {
                        db.Search.Remove(dRow);
                        db.SaveChanges();
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка в таблице <Search>!\nДанный id связан с таблицей <Teacher_predmet>, поэтому удалите его из неё.", "My App", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка в таблице <Search>!\nВы написали в id не цифру/число.", "My App", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        public bool Update(string id, int OrgName, string WorkPhone)
        {
            try
            {
                Regex SpecialSimbols = new Regex("([#]|[=]|[/]|[*]|[@]|[&]|[>]|[<]|[;]|[']|[$]|[№]|[!]|[№]|[;]|[{]|[}]|[[]|[]]|[~])");
                Regex Words = new Regex(@"(\D)");
                MatchCollection matchSpecialSymbol;
                MatchCollection matchWords;
                matchSpecialSymbol = SpecialSimbols.Matches(WorkPhone);
                matchWords = Words.Matches(WorkPhone);

                int num = Convert.ToInt32(id);
                var uRow = db.Search.Where(w => w.Id == num).FirstOrDefault();
                if (string.IsNullOrWhiteSpace(WorkPhone) == true)
                {
                    MessageBox.Show("Ошибка в таблице <Search>!\nВы забыли внести данные в поле <name>.", "My App", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (matchSpecialSymbol.Count > 0)
                {
                    MessageBox.Show("Ошибка в таблице <Search>!\nВ названии предмета не допускаются спецсимволы.", "My App", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (matchWords.Count > 0)
                {
                    MessageBox.Show("Ошибка в таблице <Search>!\nВ названии предмета вводятся только кирилица.", "My App", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (uRow == null)
                {
                    MessageBox.Show("Ошибка в таблице <Search>!\nВведите id, который уже есть в таблице.", "My App", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                uRow.OrganizationId = OrgName;
                uRow.WorkPhone = WorkPhone;
                db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Ошибка в таблице <Search>!\nВведите корректные значения.", "My App", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
    }
}
