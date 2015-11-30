using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Reflection;

namespace console1
{

	class TokenModel
	{
		public string Access_Token{ get; set;}
		public string token_type{ get; set;}
		public string expires_in{ get; set;}
		public string userName{ get; set;}
	}

	class UserInfo
	{
		public string UserId{ get; set;}
		public string Email{ get; set;}
		public string FirstName{ get; set;}
		public string LastName{ get; set;}
		public string MiddleName{ get; set;}
		public string City{ get; set;}
		public string Postal{ get; set;}
		public string Country{ get; set; }
        public string Age{ get; set;}
		public string Gender{ get; set;}
		public string SocialMediaImgUrl{ get; set;}
        public byte[] UserImgUpload{ get; set;}
		public string OneTimeKey{ get; set;}
        public Invites[] Invites{ get; set;}
		public Connection[] Connections{ get; set;}
		public Message[] Messages{ get; set;}
	}

	class Invites
	{
		
	}

	class ConnectionsInfo
	{
		public Connection[] Connections{get;set;}
	}

	class Connection
	{
		public string TenantId{ get; set;}
		public string PersonId{ get; set;}
		public string OtherPersonId{ get; set;}
		public string OtherAction{ get; set;}
	}

	class Message
	{
		public string MessageId{ get; set;}
		public string TenantId{ get; set;}
		public string SenderId{ get; set;}
		public string RecipientId{ get; set;}
		public string RecipientEmail{ get; set;}
		public string Description{ get; set;}
		public DateTime DateRecorded{ get; set;}
		public string FileName{ get; set;}
		public string SizeBytes{ get; set;}
		public string SizeTime{ get; set;}
		public string FilePath{ get; set;}
		public string Flag{ get; set;}
		public string Title{ get; set;}
		public string DateActivity{ get; set;}
		public string OneTimeKey{ get; set;}
        public string ProfileUrl { get; set; }
        public byte[] messageByteArray{ get; set;}
	}
	class A
	{
		TokenModel tm;
		string OTkey;
		string baseapiurl = "http://voiceshare.bauengroup.us/";
		string user = "deadean8@yandex.ru";
		string pass = "1234567Qq_";

		public async Task Test1 ()
		{
			try 
			{
				using (var httpClient = new HttpClient ()) 
				{
					httpClient.BaseAddress = new Uri (baseapiurl);
					httpClient.DefaultRequestHeaders.Accept.Clear ();
					httpClient.DefaultRequestHeaders.Accept.Add (new MediaTypeWithQualityHeaderValue ("application/x-www-form-urlencoded"));
					var responseMessage = await httpClient.PostAsync ("Token", new FormUrlEncodedContent (new[] {
						new KeyValuePair<string, string> ("grant_type", "password"),
						new KeyValuePair<string, string> ("username", user),
						new KeyValuePair<string, string> ("password", pass),
					}));

					Console.WriteLine (responseMessage);

					var tokenModel = await responseMessage.Content.ReadAsStringAsync();
					Console.WriteLine (tokenModel);
					tm = JsonConvert.DeserializeObject<TokenModel>(tokenModel);
					Console.WriteLine (tm.Access_Token);
				}
			} 
			catch (Exception ex) 
			{

			}
		}

		public async Task RegisterUserMobile ()
		{
			try 
			{
				using (var httpClient = new HttpClient ()) 
				{
					httpClient.BaseAddress = new Uri ("http://voiceshare.bauengroup.us/VoiceShareApi/");
					httpClient.DefaultRequestHeaders.Accept.Clear ();
					httpClient.DefaultRequestHeaders.Accept.Add (new MediaTypeWithQualityHeaderValue ("application/x-www-form-urlencoded"));
					var responseMessage = await httpClient.PostAsync ("api/Auth/RegisterUserMobile", new FormUrlEncodedContent (new[] {
						new KeyValuePair<string, string> ("TenantId", "1"),
						new KeyValuePair<string, string> ("Email", "deadean2@yandex.ru"),
						new KeyValuePair<string, string> ("FirstName", "1234567Aq_"),
						new KeyValuePair<string, string> ("LastName", "1234567Aq_"),
						new KeyValuePair<string, string> ("Password", "1234567Aq_"),
						new KeyValuePair<string, string> ("OtKey", OTkey),
					}));

					Console.WriteLine (responseMessage);
				}
			} 
			catch (Exception ex) 
			{

			}
		}

		public async Task AccountRegister ()
		{
			try 
			{
				using (var httpClient = new HttpClient ()) 
				{
					httpClient.BaseAddress = new Uri ("http://voiceshare.bauengroup.us/VoiceShareApi/");
					httpClient.DefaultRequestHeaders.Accept.Clear ();
					//httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",tm.Access_Token);
					httpClient.DefaultRequestHeaders.Accept.Add (new MediaTypeWithQualityHeaderValue ("application/x-www-form-urlencoded"));
					var responseMessage = await httpClient.PostAsync ("api/Account/Register", new FormUrlEncodedContent (new[] {
						new KeyValuePair<string, string> ("Email", "deadean3@yandex.ru"),
						new KeyValuePair<string, string> ("Password", "1234567Aq_"),
						new KeyValuePair<string, string> ("ConfirmPassword", "1234567Aq_")
					}));

					Console.WriteLine (responseMessage);
				}
			} 
			catch (Exception ex) 
			{

			}
		}

		public async Task GetOTKey ()
		{
			try 
			{
				using (var httpClient = new HttpClient ()) 
				{
					httpClient.BaseAddress = new Uri (baseapiurl);
					httpClient.DefaultRequestHeaders.Accept.Clear ();
					httpClient.DefaultRequestHeaders.Accept.Add (new MediaTypeWithQualityHeaderValue ("application/x-www-form-urlencoded"));
					var responseMessage = await httpClient.GetAsync ("api/Auth/GetOneTimeKey?email="+user);
					OTkey = await responseMessage.Content.ReadAsStringAsync();
					OTkey = RemoveSpecialChars(OTkey);
				}
			} 
			catch (Exception ex) 
			{

			}
		}

		public string RemoveSpecialChars(string input)
		{
			return Regex.Replace(input, @"[^0-9a-zA-Z\._]", string.Empty);
		}

		public UserInfo userInfo;

		public async Task GetUserInfo()
		{
			try {
				
				using(var httpClient = new HttpClient()) 
				{
					httpClient.BaseAddress = new Uri(baseapiurl);
					httpClient.DefaultRequestHeaders.Accept.Clear();
					httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",tm.Access_Token);
					httpClient.DefaultRequestHeaders.Accept.Add (new MediaTypeWithQualityHeaderValue ("application/x-www-form-urlencoded"));

					var responseMessage = await httpClient.GetAsync (string.Format("api/Person/GetAllUserInfo?OTKey={0}", OTkey));
					var resp = await responseMessage.Content.ReadAsStringAsync();
					userInfo = JsonConvert.DeserializeObject<UserInfo>(resp);

					Console.WriteLine (resp);
				}
			} catch (Exception ex) {
				
			}
		}

		public async Task GetUserConnections()
		{
			try {
				using(var httpClient = new HttpClient()) 
				{
					httpClient.BaseAddress = new Uri(baseapiurl);
					httpClient.DefaultRequestHeaders.Accept.Clear();
					httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",tm.Access_Token);
					httpClient.DefaultRequestHeaders.Accept.Add (new MediaTypeWithQualityHeaderValue ("application/x-www-form-urlencoded"));

					var responseMessage = await httpClient.GetAsync (string.Format("api/Person/GetConnectionList?OTKey={0}", OTkey));
					var resp = await responseMessage.Content.ReadAsStringAsync();
					//var connections = JsonConvert.DeserializeObject<ConnectionsInfo>(resp);

					Console.WriteLine (resp);
				}
			} catch (Exception ex) {

			}
		}

		public async Task DeleteUserConnection()
		{
			try
			{
				using (var httpClient = new HttpClient())
				{
					httpClient.BaseAddress = new Uri(baseapiurl);
					httpClient.DefaultRequestHeaders.Accept.Clear();
					httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tm.Access_Token);
					httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

					var responseMessage = 
						await httpClient.DeleteAsync(string.Format("api/Person/DeleteConnections?OTKey={0}&personId={1}"
							, OTkey, userInfo.Connections.First().OtherPersonId));

					Console.WriteLine(responseMessage);
				}
			}
			catch (Exception ex)
			{


			}
		}

        public async Task UpdateUserInfo()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(baseapiurl);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tm.Access_Token);
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

					string ImagesDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
					string filePath = Path.Combine(ImagesDirectory, "../../check33.png");
					bool isExist = File.Exists(filePath);

                    //Image img = Image.FromFile(filePath);
                    //byte[] arr;
                    //using (MemoryStream ms = new MemoryStream())
                    //{
                    //	img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    //	arr =  ms.ToArray();
                    //}

                    //this.userInfo.UserImgUpload = arr;
                    this.userInfo.UserImgUpload = File.ReadAllBytes(filePath);
					
                    var userJson = JsonConvert.SerializeObject(this.userInfo);
                    HttpContent contentPost = new StringContent(userJson, Encoding.UTF8,"application/json");
                    var responseMessage = 
                        await httpClient.PostAsync(string.Format("api/Person/UpdateUserInfo?OTKey={0}", OTkey), contentPost);
                    string mes = await responseMessage.Content.ReadAsStringAsync();

                    Console.WriteLine(responseMessage);
                }
            }
            catch (Exception ex)
            {

            }
        }

		Message modMessage;

		public async Task UploadMessage()
		{
			try
			{
				using (var httpClient = new HttpClient())
				{
					httpClient.BaseAddress = new Uri(baseapiurl);
					httpClient.DefaultRequestHeaders.Accept.Clear();
					httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tm.Access_Token);
					httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

					string ImagesDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
					string filePath = Path.Combine(ImagesDirectory, "../../test.mp3");
					bool isExist = File.Exists(filePath);

					var bytes = File.ReadAllBytes(filePath);;
					modMessage = new Message(){
                        OneTimeKey = this.userInfo.OneTimeKey,
                        messageByteArray = bytes,
                        RecipientEmail ="deadean2@yandex.ru",
                        DateRecorded = DateTime.Now,
                        Description = "test message",
                        SenderId = "1018580",
                        TenantId = "1",
                        Title = "test title"
                    };
					var json = JsonConvert.SerializeObject(this.modMessage);
					HttpContent contentPost = new StringContent(json, Encoding.UTF8,"application/json");
					var responseMessage = 
						await httpClient.PostAsync(string.Format("api/Message/UploadMessage"), contentPost);
					string mes = await responseMessage.Content.ReadAsStringAsync();

					Console.WriteLine(responseMessage);
				}
			}
			catch (Exception ex)
			{

			}
		}

		public async Task ResetPassword()
		{
			try
			{
				using (var httpClient = new HttpClient())
				{
					httpClient.BaseAddress = new Uri(baseapiurl);
					httpClient.DefaultRequestHeaders.Accept.Clear();
					httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tm.Access_Token);
					httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

					HttpContent contentPost = new StringContent("", Encoding.UTF8,"application/json");
					var responseMessage = 
						await httpClient.PostAsync(
							string.Format("api/Person/ResetPassword?OTKey={0}&Password={1}&NewPassword={2}&ConfirmPass={3}"
								, OTkey, pass, "1234567Qq_", "1234567Qq_"), contentPost);

					Console.WriteLine(responseMessage);
					Console.WriteLine(await responseMessage.Content.ReadAsStringAsync());
				}
			}
			catch (Exception ex)
			{

			}
		}

        public async Task GetUserMessages()
		{
			try {
				using(var httpClient = new HttpClient()) 
				{
					httpClient.BaseAddress = new Uri("http://voiceshare.bauengroup.us/VoiceShareApi/");
					httpClient.DefaultRequestHeaders.Accept.Clear();
					httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",tm.Access_Token);
					httpClient.DefaultRequestHeaders.Accept.Add 
					(new MediaTypeWithQualityHeaderValue ("application/json"));

					string url = "api/Message/GetUserMessages?OTKey="+OTkey+"&direction=RECV";
					var responseMessage = await httpClient.GetAsync(url);
					var res = await responseMessage.Content.ReadAsStringAsync();

					Console.WriteLine (responseMessage);
				}
			} catch (Exception ex) {

			}

		}

		public async Task GetMessageById(string id)
		{
			try {
				using(var httpClient = new HttpClient()) 
				{
					httpClient.BaseAddress = new Uri(baseapiurl);
					httpClient.DefaultRequestHeaders.Accept.Clear();
					httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",tm.Access_Token);
					httpClient.DefaultRequestHeaders.Accept.Add (new MediaTypeWithQualityHeaderValue ("application/json"));

					string url = "api/Message/GetFile?messageId="+id;
					var responseMessage = await httpClient.GetAsync(url);
					var res = await responseMessage.Content.ReadAsStringAsync();

					Console.WriteLine (responseMessage);
				}
			} catch (Exception ex) {

			}

		}

		public async Task GetUserName()
		{
			try {
				using(var httpClient = new HttpClient()) 
				{
					httpClient.BaseAddress = new Uri("http://voiceshare.bauengroup.us/VoiceShareApi/");
					httpClient.DefaultRequestHeaders.Accept.Clear();
					httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",tm.Access_Token);
					//httpClient.DefaultRequestHeaders.Accept
					//	.Add (new MediaTypeWithQualityHeaderValue ("application/json"));
					httpClient.DefaultRequestHeaders.Accept
						.Add (new MediaTypeWithQualityHeaderValue ("application/x-www-form-urlencoded"));

					var responseMessage = await httpClient.GetAsync ("GetUserName?OtKey="+OTkey);

					Console.WriteLine (responseMessage);
				}
			} catch (Exception ex) {

			}

		}



		/*public async Task Test5()
		{
			//var user = new User { //User fields, etc. };
			using(var client = new HttpClient()) 
			{
				client.BaseAddress = new Uri("http://voiceshare.bauengroup.us/VoiceShareApi/");
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",
					tm.Access_Token);
				client.DefaultRequestHeaders.Accept.Add(new
					MediaTypeWithQualityHeaderValue("application/json"));
				HttpResponseMessage response = await
					client.PostAsJsonAsync("api/Message/RetriveUserMessages", user);
				if (response.IsSuccessStatusCode) {
				}
			}
		}*/
	}
	class MainClass
	{
		public static void Main (string[] args)
		{
			A a = new A ();
			Task t = a.Test1();
			t.Wait ();
			Task t1 = a.GetOTKey ();
			t1.Wait ();
			//Task t2 = a.RegisterUserMobile ();
			//t2.Wait ();
			//Task t3 = a.GetUserName ();
			//t3.Wait ();
			//Task t4 = a.AccountRegister ();
			//t4.Wait ();
			//Task t5 = a.GetUserInfo();
			//t5.Wait ();
			//Task t6 = a.GetUserMessages();
			//t6.Wait ();
			//Task t7 = a.GetUserMessages();
			//t7.Wait ();

			Task t8 = a.GetUserInfo ();
			t8.Wait ();

			//Task t13 = a.DeleteUserConnection ();
			//t13.Wait ();

            //a.userInfo.Age = "10";
            Task t10 = a.UpdateUserInfo();
            t10.Wait();

            Task t11 = a.GetUserInfo();
            t11.Wait();

			//Task t14 = a.UploadMessage();
			//t14.Wait();

			//Task t12 = a.ResetPassword();
			//t12.Wait();

            //Task t9 = a.GetMessageById (a.userInfo.Messages.First().MessageId);
            //t9.Wait ();



        }
	}
}
