using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNC_Server_Setup_Wizard
{
    public class VNC_User
    {
        public string Name { get; set; }
        public string SID { get; set; }
        public enum DirObjectType { User, Group }
        public DirObjectType Type { get; private set; }

        public VNC_User(string username, string objectpath, string schemaclassname, string upn)
        {
            ContextType ctxtype;

            if (WindowsLogon.DomainMember) { ctxtype = ContextType.Domain; }
            else { ctxtype = ContextType.Machine; }

            PrincipalContext prictx = new PrincipalContext(ctxtype);
            UserPrincipal user = new UserPrincipal(prictx);
            GroupPrincipal group = new GroupPrincipal(prictx);
            var searcher = new PrincipalSearcher();

            if (schemaclassname.ToLower() == "user")
            {
                if (objectpath.Contains("WinNT")) { user.SamAccountName = username; }
                else { user.UserPrincipalName = upn; }
                searcher = new PrincipalSearcher(user);
                user = searcher.FindOne() as UserPrincipal;
                if (user == null) { user = new UserPrincipal(prictx); }
            }
            else if (schemaclassname.ToLower() == "group")
            {
                group.SamAccountName = username;
                searcher = new PrincipalSearcher(group);
                group = searcher.FindOne() as GroupPrincipal;
                if (group == null) { group = new GroupPrincipal(prictx); }
            }

            if (user.Sid != null)
            {
                this.Name = user.SamAccountName;
                this.SID = user.Sid.ToString();
                this.Type = DirObjectType.User;
            }
            else if (group.Sid != null)
            {
                this.Name = group.SamAccountName;
                this.SID = "%" + group.Sid.ToString();
                this.Type = DirObjectType.Group;
            }
        }
    }
}
