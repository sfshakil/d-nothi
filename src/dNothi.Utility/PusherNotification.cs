using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using PusherClient;

namespace dNothi.Utility
{
public class PusherNotification 
    {
        private Pusher pusher;
        private Channel channel;
        public event EventHandler GetDataFromServer;

        public async Task Start()
        {
            //if (instance == null)
            //{
            //    instance = this;
            //}
            //else if (instance != this)
            //{
            //    Destroy(gameObject);
            //}
            //DontDestroyOnLoad(gameObject);
            await InitialisePusher();
        }

        private async Task InitialisePusher()
        {

            if (pusher == null)
            {

                pusher = new Pusher("cff47fef296bc38258cb", new PusherOptions()
                {
                    //Authorizer = new HttpAuthorizer("https://localhost:5000/pusher/auth"),
                    Cluster = "mt1",
                    Encrypted = true
                  
                });
             
                pusher.ConnectionStateChanged += PusherOnConnectionStateChanged;
                // Subcribe to private encrypted channel
                pusher.Error += DecryptionErrorHandler;
             
                pusher.Connected += (sender) =>
                {
                   
                    // Subscribe to private channel
                    try
                    {
                        channel = pusher.SubscribeAsync("my-channel").Result;
                    }
                    catch (ChannelUnauthorizedException unauthorizedException)
                    {
                        // Handle the authorization failure - forbidden (403)
                        MessageBox.Show($"Authorization failed for {unauthorizedException.ChannelName}. {unauthorizedException.Message}");
                    }

                    channel.Bind("my-event", (PusherEvent eventData) =>
                    {
                        MessageBox.Show(eventData.Data);
                        //this.GetDataFromServer(eventData.Data as object, null);
                        //ChatMessage data = JsonConvert.DeserializeObject<ChatMessage>(eventData.Data);
                        //MessageBox.Show($"{Environment.NewLine}[{data.Name}] {data.Message}");
                    });


                };

                await pusher.ConnectAsync().ConfigureAwait(false);

                // Handle decryption error
                void DecryptionErrorHandler(object sender, PusherException error)
                {
                    if (error is ChannelDecryptionException exception)
                    {
                        string errorMsg = $"{Environment.NewLine}Decryption of message failed";
                        errorMsg += $" for ('{exception.ChannelName}',";
                        errorMsg += $" '{exception.EventName}', ";
                        errorMsg += $" '{exception.SocketID}')";
                        errorMsg += $" for reason:{Environment.NewLine}{error.Message}";
                        MessageBox.Show(errorMsg);
                    }
                }

              
            }
        }

        private void PusherOnConnectionStateChanged(object sender, ConnectionState state)
        {
           // MessageBox.Show("Connection state changed");

        }

        async Task OnApplicationQuit()
        {
            if (pusher != null)
            {
                await pusher.DisconnectAsync();
            }
        }
    }


}
