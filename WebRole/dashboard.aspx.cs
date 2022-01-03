using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebRole
{
    public partial class dashboard : System.Web.UI.Page
    {
        static User user;
        static UserFunctions userFunctions = new UserFunctions();
        static UserDataServiceContext userSVC;

        static AnnounceFunctions announceFunctions = new AnnounceFunctions();
        static AnnounceDataServiceContext announceSVC;

        static EnrollFunctions enrollFunctions = new EnrollFunctions();
        static EnrollDataServiceContext enrollSVC;
        protected void Page_Load(object sender, EventArgs e)
        {
            userSVC = userFunctions.ConnectToTable("UserTable");
            announceSVC = announceFunctions.ConnectToTable("AnnounceTable");
            enrollSVC = enrollFunctions.ConnectToTable("EnrollTable");

            string nickname = Request.QueryString["nickname"];
            string search = Request.QueryString["search"];

            var query = userSVC.CreateQuery<User>("UserTable").Where(u => (u.nickname == nickname)).Select(u => u);
            user = query.Single();

            //profile sets
            nicknameLabel.Text = user.nickname;
            if (user.age != 0)
            {
                ageLabel.Text = user.age.ToString();
            }

            if (user.interest != null)
            {
                interestLabel.Text = user.interest;
            }

            if (user.activity != null)
            {
                activityLabel.Text = user.activity;
            }

            if (user.searchingIn != null)
            {
                searchingInLabel.Text = user.searchingIn;
            }

            //set my announce table
            var announceQuery = announceSVC.CreateQuery<Announce>("AnnounceTable").Where(a => (a.landlord == nickname));
            foreach (Announce a in announceQuery)
            {
                TableRow row = new TableRow();
                TableCell address = new TableCell();
                TableCell city = new TableCell();
                TableCell prize = new TableCell();
                TableCell rooms = new TableCell();
                TableCell description = new TableCell();
                TableCell tenants = new TableCell();
                TableCell buttonCell1 = new TableCell();
                TableCell buttonCell2 = new TableCell();
                TableCell buttonCell3 = new TableCell();

                address.Text = a.address;
                city.Text = ", " + a.city;
                prize.Text = " by " + a.prize.ToString() + " per Month";
                rooms.Text = " with " + a.rooms.ToString() + " rooms ";
                description.Text = a.description + " ";

                var enrollQuery = enrollSVC.CreateQuery<Enroll>("EnrollTable").Where(en => (en.landlord == a.landlord && en.address == a.address));

                tenants.Text = " Tenants: ";
                try
                {
                    foreach (Enroll en in enrollQuery)
                    {
                        tenants.Text += en.tenant + " ";
                    }
                }
                catch (Exception) { }

                Button enrollButton = new Button();
                enrollButton.Text = "Enroll me";
                enrollButton.Attributes.Add("address", a.address);
                enrollButton.Attributes.Add("landlord", a.landlord);
                enrollButton.Click += new EventHandler(this.enrollButton_Click);

                Button updateButton = new Button();
                updateButton.Text = "Update";
                updateButton.Attributes.Add("address", a.address);
                updateButton.Attributes.Add("landlord", a.landlord);
                updateButton.Click += new EventHandler(this.updateButton_Click);

                Button deleteButton = new Button();
                deleteButton.Text = "Delete";
                deleteButton.Attributes.Add("address", a.address);
                deleteButton.Attributes.Add("landlord", a.landlord);
                deleteButton.Click += new EventHandler(this.deleteButton_Click);

                row.Cells.Add(address);
                row.Cells.Add(city);
                row.Cells.Add(prize);
                row.Cells.Add(rooms);
                row.Cells.Add(description);
                row.Cells.Add(tenants);
                row.Cells.Add(buttonCell1);
                row.Cells.Add(buttonCell2);
                row.Cells.Add(buttonCell3);

                row.Cells[6].Controls.Add(enrollButton);
                row.Cells[7].Controls.Add(updateButton);
                row.Cells[8].Controls.Add(deleteButton);

                MyAnnounceTable.Rows.Add(row);
            }

            if (search == null || search == "")
            {
                //set Announce Table
                announceQuery = announceSVC.CreateQuery<Announce>("AnnounceTable").Where(a => (a.landlord != nickname));
                foreach (Announce a in announceQuery)
                {
                    int occupiedRooms = enrollSVC.CreateQuery<Enroll>("EnrollTable").Where(en => (en.landlord == a.landlord && en.address == a.address)).ToList().Count();

                    if (occupiedRooms < a.rooms)
                    {

                        TableRow row = new TableRow();
                        TableCell address = new TableCell();
                        TableCell city = new TableCell();
                        TableCell prize = new TableCell();
                        TableCell rooms = new TableCell();
                        TableCell description = new TableCell();
                        TableCell tenants = new TableCell();
                        TableCell landlord = new TableCell();
                        TableCell buttonCell = new TableCell();

                        address.Text = a.address + ", ";
                        city.Text = a.city;
                        prize.Text = " by " + a.prize.ToString() + " per Month";
                        rooms.Text = " with " + a.rooms.ToString() + " rooms ";
                        description.Text = a.description + " ";
                        landlord.Text = " landlord is " + a.landlord;

                        var enrollQuery = enrollSVC.CreateQuery<Enroll>("EnrollTable").Where(en => (en.landlord == a.landlord && en.address == a.address));

                        tenants.Text = " Tenants: ";
                        try
                        {
                            foreach (Enroll en in enrollQuery)
                            {
                                tenants.Text += en.tenant + " ";
                            }
                        }
                        catch (Exception) { }

                        Button enrollButton = new Button();
                        enrollButton.Text = "Enroll me";
                        enrollButton.Attributes.Add("address", a.address);
                        enrollButton.Attributes.Add("landlord", a.landlord);
                        enrollButton.Click += new EventHandler(this.enrollButton_Click);


                        row.Cells.Add(address);
                        row.Cells.Add(city);
                        row.Cells.Add(prize);
                        row.Cells.Add(rooms);
                        row.Cells.Add(description);
                        row.Cells.Add(tenants);
                        row.Cells.Add(landlord);
                        row.Cells.Add(buttonCell);

                        row.Cells[7].Controls.Add(enrollButton);

                        AnnounceTable.Rows.Add(row);
                    }
                }

                //set Users Table
                query = userSVC.CreateQuery<User>("UserTable").Where(u => u.nickname != user.nickname).Select(u => u);
                foreach (User u in query)
                {
                    TableRow row = new TableRow();
                    TableCell nick = new TableCell();
                    TableCell age = new TableCell();
                    TableCell interest = new TableCell();
                    TableCell activity = new TableCell();
                    TableCell searchingIn = new TableCell();
                    TableCell buttonCell = new TableCell();

                    nick.Text = u.nickname + ", ";
                    if (u.age == 0)
                    {
                        age.Text = "";
                    }
                    else
                    {
                        age.Text = u.age.ToString() + " years old ";
                    }

                    if (u.interest != null)
                    {
                        interest.Text = " interested in " + u.interest;
                    }
                    else
                    {
                        interest.Text = "";
                    }

                    if (u.activity != null)
                    {
                        activity.Text = " currently " + u.activity;
                    }
                    else
                    {
                        activity.Text = "";
                    }

                    if (u.searchingIn != null)
                    {
                        searchingIn.Text = " searching flat in " + u.searchingIn;
                    }
                    else
                    {
                        searchingIn.Text = "";
                    }

                    Button contactButton = new Button();
                    contactButton.Text = "Contact";
                    contactButton.Attributes.Add("email", u.email);
                    contactButton.Click += new EventHandler(this.contactButton_Click);

                    row.Cells.Add(nick);
                    row.Cells.Add(age);
                    row.Cells.Add(interest);
                    row.Cells.Add(activity);
                    row.Cells.Add(searchingIn);
                    row.Cells.Add(buttonCell);

                    row.Cells[5].Controls.Add(contactButton);

                    UserTable.Rows.Add(row);
                }
            }
            else
            {
                //set Announce Table
                announceQuery = announceSVC.CreateQuery<Announce>("AnnounceTable").Where(a => (a.landlord != nickname && a.city == search));
                foreach (Announce a in announceQuery)
                {
                    int occupiedRooms = enrollSVC.CreateQuery<Enroll>("EnrollTable").Where(en => (en.landlord == a.landlord && en.address == a.address)).ToList().Count();

                    if (occupiedRooms < a.rooms)
                    {

                        TableRow row = new TableRow();
                        TableCell address = new TableCell();
                        TableCell city = new TableCell();
                        TableCell prize = new TableCell();
                        TableCell rooms = new TableCell();
                        TableCell description = new TableCell();
                        TableCell tenants = new TableCell();
                        TableCell landlord = new TableCell();
                        TableCell buttonCell = new TableCell();

                        address.Text = a.address + ", ";
                        city.Text = a.city;
                        prize.Text = " by " + a.prize.ToString() + " per Month";
                        rooms.Text = " with " + a.rooms.ToString() + " rooms ";
                        description.Text = a.description + " ";
                        landlord.Text = " landlord is " + a.landlord;

                        var enrollQuery = enrollSVC.CreateQuery<Enroll>("EnrollTable").Where(en => (en.landlord == a.landlord && en.address == a.address));

                        tenants.Text = " Tenants: ";
                        try
                        {
                            foreach (Enroll en in enrollQuery)
                            {
                                tenants.Text += en.tenant + " ";
                            }
                        }
                        catch (Exception) { }

                        Button enrollButton = new Button();
                        enrollButton.Text = "Enroll me";
                        enrollButton.Attributes.Add("address", a.address);
                        enrollButton.Attributes.Add("landlord", a.landlord);
                        enrollButton.Click += new EventHandler(this.enrollButton_Click);


                        row.Cells.Add(address);
                        row.Cells.Add(city);
                        row.Cells.Add(prize);
                        row.Cells.Add(rooms);
                        row.Cells.Add(description);
                        row.Cells.Add(tenants);
                        row.Cells.Add(landlord);
                        row.Cells.Add(buttonCell);

                        row.Cells[7].Controls.Add(enrollButton);

                        AnnounceTable.Rows.Add(row);
                    }
                }

                //set Users Table
                query = userSVC.CreateQuery<User>("UserTable").Where(u => u.nickname != user.nickname && u.searchingIn == search).Select(u => u);
                foreach (User u in query)
                {
                    TableRow row = new TableRow();
                    TableCell nick = new TableCell();
                    TableCell age = new TableCell();
                    TableCell interest = new TableCell();
                    TableCell activity = new TableCell();
                    TableCell searchingIn = new TableCell();
                    TableCell buttonCell = new TableCell();

                    nick.Text = u.nickname + ", ";
                    if (u.age == 0)
                    {
                        age.Text = "";
                    }
                    else
                    {
                        age.Text = u.age.ToString() + " years old ";
                    }

                    if (u.interest != null)
                    {
                        interest.Text = " interested in " + u.interest;
                    }
                    else
                    {
                        interest.Text = "";
                    }

                    if (u.activity != null)
                    {
                        activity.Text = " currently " + u.activity;
                    }
                    else
                    {
                        activity.Text = "";
                    }

                    if (u.searchingIn != null)
                    {
                        searchingIn.Text = " searching flat in " + u.searchingIn;
                    }
                    else
                    {
                        searchingIn.Text = "";
                    }

                    Button contactButton = new Button();
                    contactButton.Text = "Contact";
                    contactButton.Attributes.Add("email", u.email);
                    contactButton.Click += new EventHandler(this.contactButton_Click);

                    row.Cells.Add(nick);
                    row.Cells.Add(age);
                    row.Cells.Add(interest);
                    row.Cells.Add(activity);
                    row.Cells.Add(searchingIn);
                    row.Cells.Add(buttonCell);

                    row.Cells[5].Controls.Add(contactButton);

                    UserTable.Rows.Add(row);
                }
            }
        }

        protected void CreateAnnounce_Click(object sender, EventArgs e)
        {
            string address = formAddress.Text;
            string city = formCity.Text;
            int rooms = int.Parse(formRooms.Text);
            double prize = double.Parse(formPrize.Text);
            string description = formDescription.Text;

            Announce announce = new Announce(address, city, rooms, prize, description);
            announce.landlord = user.nickname;
            announceSVC.AddObject("AnnounceTable", announce);
            announceSVC.SaveChanges();

            Response.Redirect("dashboard.aspx?nickname=" + user.nickname);
        }

        protected void UpdateAnnounce_Click(object sender, EventArgs e)
        {
            
        }

        protected void updateProfileButton_Click(object sender, EventArgs e)
        {
            string interest = profileInterestTextBox.Text;
            string activity = profileActivityTextBox.Text;
            string searchingIn = profileSearchingInTextBox.Text;

            if(profileAgeTextBox.Text != "")
            {
                int age = int.Parse(profileAgeTextBox.Text);
                user.age = age;
            }

            if(interest != "")
            {
                user.interest = interest;
            }
            
            if(activity != "")
            {
                user.activity = activity;
            }
            
            if(searchingIn != "")
            {
                user.searchingIn = searchingIn;
            }
            
            userSVC.UpdateObject(user);
            userSVC.SaveChanges();

            Response.Redirect("dashboard.aspx?nickname=" + user.nickname);
        }

        protected void contactButton_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            string email = b.Attributes["email"];

            Response.Write("<script>alert('Contact at " + email + "')</script>");
        }

        protected void enrollButton_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            string address = b.Attributes["address"];
            string landlord = b.Attributes["landlord"];

            var enrollQuery = enrollSVC.CreateQuery<Enroll>("EnrollTable").Where(en => (en.landlord == landlord && en.address == address && en.tenant == user.nickname));

            try
            {
                Enroll enroll = enrollQuery.Single();
                enrollSVC.DeleteObject(enroll);
                enrollSVC.SaveChanges();
            }
            catch (Exception)
            {
                Enroll enroll = new Enroll(address, landlord, user.nickname);
                enrollSVC.AddObject("EnrollTable", enroll);
                enrollSVC.SaveChanges();
            }

            Response.Redirect("dashboard.aspx?nickname=" + user.nickname);
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            string address = b.Attributes["address"];
            string landlord = b.Attributes["landlord"];

            var announceQuery = announceSVC.CreateQuery<Announce>("AnnounceTable").Where(a => (a.landlord.Equals(landlord) && a.address.Equals(address)));
            Announce announce = announceQuery.First();

            formAddress.Text = announce.address;
            formAddress.Enabled = false;

            formCity.Text = announce.city;
            formRooms.Text = announce.rooms.ToString();
            formPrize.Text = announce.prize.ToString();
            formDescription.Text = announce.description;

            CreateAnnounce.Visible = false;
            CreateAnnounce.Enabled = false;

            UpdateFormButton.Visible = true;
            UpdateFormButton.Enabled = true;
        }

        protected void deleteButton_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            string address = b.Attributes["address"];
            string landlord = b.Attributes["landlord"];

            var announceQuery = announceSVC.CreateQuery<Announce>("AnnounceTable").Where(a => (a.landlord.Equals(landlord) && a.address.Equals(address)));
            Announce announce = announceQuery.First();
            announceSVC.DeleteObject(announce);
            announceSVC.SaveChanges();

            Response.Redirect("dashboard.aspx?nickname=" + user.nickname);
        }

        protected void UpdateFormButton_Click(object sender, EventArgs e)
        {
            string address = formAddress.Text;
            string city = formCity.Text;
            int rooms = int.Parse(formRooms.Text);
            double prize = double.Parse(formPrize.Text);
            string description = formDescription.Text;

            var announceQuery = announceSVC.CreateQuery<Announce>("AnnounceTable").Where(a => (a.address == address && a.landlord == user.nickname));

            Announce announce = announceQuery.Single();

            announce.city = city;
            announce.rooms = rooms;
            announce.prize = prize;
            announce.description = description;

            announceSVC.UpdateObject(announce);
            announceSVC.SaveChanges();

            Response.Redirect("dashboard.aspx?nickname=" + user.nickname);
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            string search = SearchBar.Text;
            Response.Redirect("dashboard.aspx?nickname=" + user.nickname + "&search=" + search);
        }
    }
}