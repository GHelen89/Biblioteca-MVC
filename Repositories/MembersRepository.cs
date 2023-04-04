using Biblioteca_MVC.DataContext;
using Biblioteca_MVC.Models;
using Biblioteca_MVC.ViewModels;
using Microsoft.EntityFrameworkCore;


namespace Biblioteca_MVC.Repositories
{
    public class MembersRepository
    {
        private readonly BibliotecaDBDataContext _context;

        public MemberBookLoansViewModel GetMemberBookLoans(Guid memberID)
        {
            MemberBookLoansViewModel memberBookLoansViewModel = new MemberBookLoansViewModel();
            MembersModel member = _context.Members.FirstOrDefault(x => x.IDMembru == memberID);
            if (member != null)
            {
                memberBookLoansViewModel.NumeMembru = member.NumeMembru;
                //memberBookLoansViewModel.Position = member.Position;
                //memberBookLoansViewModel.Title = member.Title;
                IQueryable<BookLoansModel> memberBookLoans = _context.BookLoans.Where(x => x.IDMembru == memberID);
                foreach (BookLoansModel dbBookLoans in memberBookLoans)
                {
                    memberBookLoansViewModel.BookLoans.Add(dbBookLoans);
                }
            }
            return memberBookLoansViewModel;
        }
        public MembersRepository(BibliotecaDBDataContext context)
        {
            _context = context;
        }
        public DbSet<MembersModel> GetMembers()
        {
            return _context.Members;
        }
        public void Add(MembersModel model)
        {
            model.IDMembru = Guid.NewGuid();
            _context.Members.Add(model);
            _context.SaveChanges();
        }
        public MembersModel GetMemberById(Guid id)
        {
            MembersModel member = _context.Members.FirstOrDefault(x => x.IDMembru == id);
            return member ;
        }
        public void Update (MembersModel model)
        {
            _context.Members.Update(model);
            _context.SaveChanges();
        }
        public void Delete (Guid id)
        {
            MembersModel member =GetMemberById(id);
            _context.Members.Remove(member);
            _context.SaveChanges ();
        }
    }
}
