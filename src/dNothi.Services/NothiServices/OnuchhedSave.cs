using dNothi.Constants;
using dNothi.JsonParser.Entity.Dak;
using dNothi.JsonParser.Entity.Nothi;
using dNothi.Services.DakServices;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace dNothi.Services.NothiServices
{
    public class OnuchhedSave : IOnucchedSave
    {
        public NothiOnuchhedSaveResponse GetNothiOnuchhedSave(DakUserParam dakUserParam, DakUploadedFileResponse onuchhedSaveWithAttachment, NothiListRecordsDTO nothiListRecordsDTO, NoteSaveDTO newnotedata, string editorEncodedData)
        {
            try
            {


                var client = new RestClient(GetAPIDomain() + GetNoteOnuchhedSaveEndPoint());
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("api-version", GetAPIVersion());
                request.AddHeader("Authorization", "Bearer " + dakUserParam.token);
                request.AlwaysMultipartFormData = true;
                var serializedObject1 = JsonConvert.SerializeObject(dakUserParam);
                request.AddParameter("cdesk", serializedObject1);
                //request.AddParameter("onucched", "{\"nothi_id\":\""+newnotedata.nothi_id+"\",\"nothi_office\":\""+newnotedata.office_id+"\",\"note_id\":\""+newnotedata.note_id+"\",\"id\":\"0\",\"note_description\":\""+ editorEncodedData + "\",\"attachments\":\"{\""+ onuchhedSaveWithAttachment.data[0].id+ "\":\"{\"file_info\":\"{\"id\":\""+ onuchhedSaveWithAttachment.data[0].id +"\",\"img_base64\":\""+ onuchhedSaveWithAttachment.data[0].img_base64+"\",\"user_file_name\":\""+ onuchhedSaveWithAttachment.data[0].user_file_name+"\",\"file_name\":\""+ onuchhedSaveWithAttachment.data[0].file_name+"\",\"attachment_type\":\""+ onuchhedSaveWithAttachment.data[0].attachment_type+ "\",\"file_size_in_kb\":\"" + onuchhedSaveWithAttachment.data[0].file_size_in_kb+"\",\"url\":\""+ onuchhedSaveWithAttachment.data[0].url+ "\",\"thumb_url\":\""+ onuchhedSaveWithAttachment.data[0].thumb_url+ "\",\"delete_token\":\""+ onuchhedSaveWithAttachment.data[0].delete_token+ "\",\"delete_url\":\""+ onuchhedSaveWithAttachment.data[0].delete_url+ "\"}\"}\"}\"}     ");
                //request.AddParameter("onucched", "{\"nothi_id\":\""+ newnotedata.nothi_id + "\",\"nothi_office\":\"" + newnotedata.office_id + "\",\"note_id\":\"" + newnotedata.note_id + "\",\"id\":\"0\",\"note_description\":\"" + editorEncodedData + "\",\"attachments\":\"{\"" + onuchhedSaveWithAttachment.data[0].id + "\":\"{\"file_info\":\"{\\\"id\\\":\"" + onuchhedSaveWithAttachment.data[0].id + "\",\\\"img_base64\\\":\\\"" + onuchhedSaveWithAttachment.data[0].img_base64 + "\",\\\"user_file_name\\\":\\\"" + onuchhedSaveWithAttachment.data[0].user_file_name + "\",\\\"file_name\\\":\\\"" + onuchhedSaveWithAttachment.data[0].file_name + "\",\\\"attachment_type\\\":\\\"" + onuchhedSaveWithAttachment.data[0].attachment_type + "\",\\\"file_size_in_kb\\\":\\\"" + onuchhedSaveWithAttachment.data[0].file_size_in_kb + "\",\\\"url\\\":\\\"" + onuchhedSaveWithAttachment.data[0].url + "\",\\\"delete_token\\\":\\\"" + onuchhedSaveWithAttachment.data[0].delete_token + "\"}\"}\"}\"}");
                //var str = "attachments\":{\"" + onuchhedSaveWithAttachment.data[0].id + "\":{\"file_info\":\"{\\\"id\\\":" + onuchhedSaveWithAttachment.data[0].id + ",\\\"img_base64\\\":\\\"" + onuchhedSaveWithAttachment.data[0].img_base64 + "\\\",\\\"user_file_name\\\":\\\"" + onuchhedSaveWithAttachment.data[0].user_file_name + "\",\\\"file_name\\\":\\\"" + onuchhedSaveWithAttachment.data[0].file_name + "\\\",\\\"attachment_type\\\":\\\"" + onuchhedSaveWithAttachment.data[0].attachment_type + "\\\",\\\"file_size_in_kb\\\":\\\"" + onuchhedSaveWithAttachment.data[0].file_size_in_kb + "\\\",\\\"url\\\":\\\"" + onuchhedSaveWithAttachment.data[0].url + "\\\"}\"}}}")"";
                //var str2 = "{\"nothi_id\":\"" + newnotedata.nothi_id + "\",\"nothi_office\":\"" + newnotedata.office_id + "\",\"note_id\":\"" + newnotedata.note_id + "\",\"id\":\"0\",\"note_description\":\"" + editorEncodedData + "\",\"attachments\":{\"" + onuchhedSaveWithAttachment.data[0].id + "\":{\"file_info\":\"{\\\"id\\\":" + onuchhedSaveWithAttachment.data[0].id + ",\\\"img_base64\\\":\\\"" + onuchhedSaveWithAttachment.data[0].img_base64 + "\\\",\\\"user_file_name\\\":\\\"" + onuchhedSaveWithAttachment.data[0].user_file_name + "\",\\\"file_name\\\":\\\"" + onuchhedSaveWithAttachment.data[0].file_name + "\\\",\\\"attachment_type\\\":\\\"" + onuchhedSaveWithAttachment.data[0].attachment_type + "\\\",\\\"file_size_in_kb\\\":\\\"" + onuchhedSaveWithAttachment.data[0].file_size_in_kb + "\\\",\\\"url\\\":\\\"" + onuchhedSaveWithAttachment.data[0].url + "\\\"}\"}}}";


                FileInfo f1 = new FileInfo();
                f1.attachment_type = onuchhedSaveWithAttachment.data[0].attachment_type;
                f1.user_file_name = onuchhedSaveWithAttachment.data[0].user_file_name;
                f1.id = onuchhedSaveWithAttachment.data[0].id;
                f1.file_name = onuchhedSaveWithAttachment.data[0].file_name;
                f1.file_size_in_kb = onuchhedSaveWithAttachment.data[0].file_size_in_kb;
                f1.img_base64 = onuchhedSaveWithAttachment.data[0].img_base64;
                f1.url = onuchhedSaveWithAttachment.data[0].url;

                var fileinfo = JsonConvert.SerializeObject(f1);

                var attachment = "\"{\"" + onuchhedSaveWithAttachment.data[0].id + "\":\"" + fileinfo +"\"}\"";

                Onuchhed o1 = new Onuchhed();
                o1.nothi_id = newnotedata.nothi_id.ToString();
                o1.nothi_office = newnotedata.office_id.ToString();
                o1.note_description = editorEncodedData;
                o1.note_id = newnotedata.note_id.ToString();
                o1.id = "0";
                o1.attachments = attachment;

                var onuchhed = JsonConvert.SerializeObject(o1);

                request.AddParameter("onucched", onuchhed);

                //var onuchhedSaveWithAttachmentsl = JsonConvert.SerializeObject(onuchhedSaveWithAttachment.data[0]);
                //var newnotedatasl = JsonConvert.SerializeObject(newnotedata);
                //request.AddParameter("onucched", serializedObject2 + serializedObject3);
                //request.AddParameter("onucched", "{\"nothi_id\":\"" + newnotedata.nothi_id + "\",\"nothi_office\":\"" + newnotedata.office_id + "\",\"note_id\":\"" + newnotedata.note_id + "\",\"id\":\"0\",\"note_description\":\"" + editorEncodedData + "\",\"attachments\":{\"" + onuchhedSaveWithAttachment.data[0].id + "\":{\"file_info\":\"{\\\"id\\\":" + onuchhedSaveWithAttachment.data[0].id + ",\\\"img_base64\\\":\\\"" + onuchhedSaveWithAttachment.data[0].img_base64 + "\\\",\\\"user_file_name\\\":\\\"" + onuchhedSaveWithAttachment.data[0].user_file_name + "\",\\\"file_name\\\":\\\"" + onuchhedSaveWithAttachment.data[0].file_name + "\\\",\\\"attachment_type\\\":\\\"" + onuchhedSaveWithAttachment.data[0].attachment_type + "\\\",\\\"file_size_in_kb\\\":\\\"" + onuchhedSaveWithAttachment.data[0].file_size_in_kb + "\\\",\\\"url\\\":\\\"" + onuchhedSaveWithAttachment.data[0].url + "\\\"}\"}}}");
                //request.AddParameter("onucched", "{\"nothi_id\":\"232\",\"nothi_office\":\"65\",\"note_id\":\"439\",\"id\":\"0\",\"note_description\":\"PHA+PHNwYW4gaWQ9Im5vdGVfc3ViIj7gpqjgpqXgpr\\/gpqTgp4cg4KaJ4Kaq4Ka44KeN4Kal4Ka+4Kaq4KaoIOCmmuCnh+CmleCmv+Cmgjwvc3Bhbj48L3A+\",\"attachments\":{\"13203\":{\"file_info\":\"{\\\"id\\\":13203,\\\"img_base64\\\":\\\"iVBORw0KGgoAAAANSUhEUgAAAKwAAABACAYAAACHt5whAAAMS2lDQ1BJQ0MgUHJvZmlsZQAASImVVwdUU8kanltSSWiBCEgJvYkiNYCUEFoEAamCjZAEEkqICUHE7rKsgmsXEVBXdFXERdcCyFqxl0Wx94cFFWVdLNhQeZMC67rnvXfef87c+e4\\/\\/3x\\/uXPvnQFAr5Yvk+Wh+gDkSwvlCZGhrAlp6SzSI0AGTKALfIEPX6CQceLjYwCUwf7v8vYaQFT9ZTcV1z\\/H\\/6sYCEUKAQBIPMSZQoUgH+K9AOClApm8EAAiG+ptpxfKVHgSxEZyGCDEMhXO1uBSFc7U4Cq1TVICF+IdAJBpfL48GwDdFqhnFQmyIY\\/uDYjdpUKJFAA9MsRBAjFfCHEUxCPy8wtUGNoBp8yveLL\\/xpk5xMnnZw9hTS5qIYdJFLI8\\/oz\\/sxz\\/W\\/LzlIM+HGCjieVRCaqcYd1u5BZEqzAN4h5pZmwcxIYQv5cI1fYQo1SxMipZY4+aCxRcWDP4pAHqLuSHRUNsDnGENC82RqvPzJJE8CCGKwQtlhTykrRzF4oU4Ylazlp5QULcIM6ScznauY18udqvyv64MjeZo+W\\/IRbxBvnflIiTUjUxY9QiSUosxLoQMxW5idEaG8yuRMyNHbSRKxNU8dtB7C+SRoZq+LEpWfKIBK29PF8xmC+2UCzhxWpxdaE4KUrLs0PAV8dvAnGLSMpJHuQRKSbEDOYiFIWFa3LHLoqkydp8sU5ZYWiCdu4rWV681h6nivIiVXobiM0VRYnauXhQIVyQGn48VlYYn6SJE8\\/M4Y+N18SDF4MYwAVhgAWUsGWCApADJO09zT3wTjMSAfhADrKBCLhpNYMzUtUjUnhNBCXgD4hEQDE0L1Q9KgJFUP95SKu5uoEs9WiRekYueAxxPogGefBeqZ4lHfKWAh5BjeQf3gUw1jzYVGP\\/1HGgJkarUQ7ysvQGLYnhxDBiFDGC6Iyb4UF4AB4DryGweeBs3G8w2r\\/sCY8JHYQHhKuETsLNqZIF8m\\/yYYFxoBN6iNDmnPl1zrgDZPXGQ\\/FAyA+5cSZuBtxwL+iJgwdD395Qy9VGrsr+W+6\\/5fBV1bV2FHcKShlGCaE4fTtT10XXe4hFVdOvK6SJNXOortyhkW\\/9c7+qtBD20d9aYguxPdgp7Ch2BjuANQMWdhhrwc5jB1V4aBU9Uq+iQW8J6nhyIY\\/kH\\/74Wp+qSircG9y73T9pxgpFxarvI+AWyGbIJdniQhYHfvlFLJ5UMHIEy8Pdwx0A1X9E85l6zVT\\/HxDm2b90BVQA2Lvg+7PqL50Afpf3rwHANPIvnW0fAPRWAJoSBEp5kUaHqy4EQAV68I0yBZbAFjjBfDyADwgAISAcjAVxIAmkgSmwymK4nuVgOpgF5oMyUAGWgdWgGmwAm8A28AvYDZrBAXAUnATnwEVwFdyGq6cLPAe94C3oRxCEhNARBmKKWCH2iCvigbCRICQciUESkDQkA8lGpIgSmYV8h1QgK5BqZCNSj\\/yK7EeOImeQDuQmch\\/pRl4hH1EMpaFGqAXqgI5C2SgHjUaT0MloNjoNLUFL0SVoFVqH7kCb0KPoOfQq2ok+R\\/swgOlgTMwac8PYGBeLw9KxLEyOzcHKsUqsDmvEWuFzvox1Yj3YB5yIM3AW7gZXcBSejAvwafgcfDFejW\\/Dm\\/Dj+GX8Pt6LfyHQCeYEV4I\\/gUeYQMgmTCeUESoJWwj7CCfg29RFeEskEplER6IvfBvTiDnEmcTFxHXEncQjxA7iQ2IfiUQyJbmSAklxJD6pkFRGWkvaQTpMukTqIr0n65CtyB7kCHI6WUpeQK4kbycfIl8iPyH3U\\/Qp9hR\\/ShxFSJlBWUrZTGmlXKB0UfqpBlRHaiA1iZpDnU+tojZST1DvUF\\/r6OjY6PjpjNeR6MzTqdLZpXNa577OB5ohzYXGpU2iKWlLaFtpR2g3aa\\/pdLoDPYSeTi+kL6HX04\\/R79Hf6zJ0R+rydIW6c3VrdJt0L+m+0KPo2etx9KbolehV6u3Ru6DXo0\\/Rd9Dn6vP15+jX6O\\/Xv67fZ8AwGG0QZ5BvsNhgu8EZg6eGJEMHw3BDoWGp4SbDY4YPGRjDlsFlCBjfMTYzTjC6jIhGjkY8oxyjCqNfjNqNeo0Njb2MU4yLjWuMDxp3MjGmA5PHzGMuZe5mXmN+HGYxjDNMNGzRsMZhl4a9MxluEmIiMik32Wly1eSjKcs03DTXdLlps+ldM9zMxWy82XSz9WYnzHqGGw0PGC4YXj589\\/Bb5qi5i3mC+UzzTebnzfssLC0iLWQWay2OWfRYMi1DLHMsV1kesuy2YlgFWUmsVlkdtnrGMmZxWHmsKtZxVq+1uXWUtdJ6o3W7db+No02yzQKbnTZ3bam2bNss21W2bba9dlZ24+xm2TXY3bKn2LPtxfZr7E\\/Zv3NwdEh1+MGh2eGpo4kjz7HEscHxjhPdKdhpmlOd0xVnojPbOdd5nfNFF9TF20XsUuNywRV19XGVuK5z7RhBGOE3QjqibsR1N5obx63IrcHt\\/kjmyJiRC0Y2j3wxym5U+qjlo06N+uLu7Z7nvtn99mjD0WNHLxjdOvqVh4uHwKPG44on3TPCc65ni+dLL1cvkdd6rxveDO9x3j94t3l\\/9vH1kfs0+nT72vlm+Nb6XmcbsePZi9mn\\/Qh+oX5z\\/Q74ffD38S\\/03+3\\/Z4BbQG7A9oCnYxzHiMZsHvMw0CaQH7gxsDOIFZQR9FNQZ7B1MD+4LvhBiG2IMGRLyBOOMyeHs4PzItQ9VB66L\\/Qd1587m3skDAuLDCsPaw83DE8Orw6\\/F2ETkR3RENEb6R05M\\/JIFCEqOmp51HWeBU\\/Aq+f1jvUdO3vs8WhadGJ0dfSDGJcYeUzrOHTc2HErx92JtY+VxjbHgThe3Mq4u\\/GO8dPifxtPHB8\\/vmb844TRCbMSTiUyEqcmbk98mxSatDTpdrJTsjK5LUUvZVJKfcq71LDUFamdE0ZNmD3hXJpZmiStJZ2UnpK+Jb1vYvjE1RO7JnlPKpt0bbLj5OLJZ6aYTcmbcnCq3lT+1D0ZhIzUjO0Zn\\/hx\\/Dp+XyYvszazV8AVrBE8F4YIVwm7RYGiFaInWYFZK7KeZgdmr8zuFgeLK8U9Eq6kWvIyJypnQ8673LjcrbkDeal5O\\/PJ+Rn5+6WG0lzp8QLLguKCDpmrrEzWOc1\\/2uppvfJo+RYFopisaCk0ghv280on5ffK+0VBRTVF76enTN9TbFAsLT4\\/w2XGohlPSiJKfp6JzxTMbJtlPWv+rPuzObM3zkHmZM5pm2s7t3Ru17zIedvmU+fnzv99gfuCFQvefJf6XWupRem80offR37fUKZbJi+7\\/kPADxsW4gslC9sXeS5au+hLubD8bIV7RWXFp8WCxWd\\/HP1j1Y8DS7KWtC\\/1Wbp+GXGZdNm15cHLt60wWFGy4uHKcSubVrFWla96s3rq6jOVXpUb1lDXKNd0VsVUtay1W7ts7adqcfXVmtCanbXmtYtq360Trru0PmR94waLDRUbPv4k+enGxsiNTXUOdZWbiJuKNj3enLL51M\\/sn+u3mG2p2PJ5q3Rr57aEbcfrfevrt5tvX9qANigbundM2nHxl7BfWhrdGjfuZO6s2AV2KXc9+zXj12u7o3e37WHvadxrv7d2H2NfeRPSNKOpt1nc3NmS1tKxf+z+ttaA1n2\\/jfxt6wHrAzUHjQ8uPUQ9VHpo4HDJ4b4jsiM9R7OPPmyb2nb72IRjV46PP95+IvrE6ZMRJ4+d4pw6fDrw9IEz\\/mf2n2WfbT7nc67pvPf5fb97\\/76v3ae96YLvhZaLfhdbO8Z0HLoUfOno5bDLJ6\\/wrpy7Gnu141rytRvXJ13vvCG88fRm3s2Xt4pu9d+ed4dwp\\/yu\\/t3Ke+b36v7l\\/K+dnT6dB++H3T\\/\\/IPHB7YeCh88fKR596ip9TH9c+cTqSf1Tj6cHuiO6Lz6b+Kzruex5f0\\/ZHwZ\\/1L5werH3z5A\\/z\\/dO6O16KX858Grxa9PXW994vWnri++79zb\\/bf+78vem77d9YH849TH145P+6Z9In6o+O39u\\/RL95c5A\\/sCAjC\\/nq7cCGGxoVhYAr7bCfUIaAIyLAFAnas55akE0Z1M1Av8Ja86CavEBYNMRAJLmARAD+7WwdwhRH0mAaqueFAJQT8+hphVFlqeHhosGTzyE9wMDry0AIMF9y2f5wED\\/uoGBz5thsDcBODJNc75UCRGeDX7yU6GrXoYy8I38G4WJfNA7WQ92AAAACXBIWXMAABYlAAAWJQFJUiTwAAABnGlUWHRYTUw6Y29tLmFkb2JlLnhtcAAAAAAAPHg6eG1wbWV0YSB4bWxuczp4PSJhZG9iZTpuczptZXRhLyIgeDp4bXB0az0iWE1QIENvcmUgNS40LjAiPgogICA8cmRmOlJERiB4bWxuczpyZGY9Imh0dHA6Ly93d3cudzMub3JnLzE5OTkvMDIvMjItcmRmLXN5bnRheC1ucyMiPgogICAgICA8cmRmOkRlc2NyaXB0aW9uIHJkZjphYm91dD0iIgogICAgICAgICAgICB4bWxuczpleGlmPSJodHRwOi8vbnMuYWRvYmUuY29tL2V4aWYvMS4wLyI+CiAgICAgICAgIDxleGlmOlBpeGVsWERpbWVuc2lvbj4xNzI8L2V4aWY6UGl4ZWxYRGltZW5zaW9uPgogICAgICAgICA8ZXhpZjpQaXhlbFlEaW1lbnNpb24+NjQ8L2V4aWY6UGl4ZWxZRGltZW5zaW9uPgogICAgICA8L3JkZjpEZXNjcmlwdGlvbj4KICAgPC9yZGY6UkRGPgo8L3g6eG1wbWV0YT4KZ6NtQgAAABxpRE9UAAAAAgAAAAAAAAAgAAAAKAAAACAAAAAgAAAHa8O\\/Bl8AAAc3SURBVHgB7Jt5SFVPFMeP7XsYLVjRRhoVGGJUJhRF+46pbVQWSdJiaovRH0VQEfVHK0VERUUG7URRFhlUIJlYENEilQmp7Ybt2\\/nNd2De767xfs\\/ehdtvBp5z3733zJl75jPnnjnzjGBRSBdtAZ9YIEID65OR0t2UFtDAahB8ZQENrK+GS3dWA6sZ8JUFNLC+Gi7dWQ2sZsBXFtDA+mq4dGc1sJoBX1lAA+ur4dKd1cBqBnxlAQ2sr4ZLd1YDqxnwlQU0sL4aLt1ZDaxmwFcW0MD6arh0Zz0DVv3sNiIiQltdWyBkC3gG7M2bN+nRo0fUr18\\/6tGjR8gddhJ8\\/fo1XblyhR48eOB02fHcsGHDqHXr1nTt2jWqqKhwvMd4sl69etS8eXOKjIykVq1aUbdu3ahLly7UuHFj422242D7FhMTQ4MHD6b27dvb2nA7UVRURDdu3KCamhq3W6hu3bo0YsQIaXfXm3x0wRNg4V03b95Mx48fp6VLl9LUqVP\\/qIm+f\\/9Or169khPi1KlTdO7cOfndqqRPnz6UkpJCiYmJ1L17d2rQoAFVVlbS\\/fv36fDhw1RQUEBfvnwxibVs2VICijfDu3fv6OPHj4RjANypUyfZVnJyMvXt25caNmxoksUX9O3ly5eybydPnqTz588TILaWzp0709q1a2ny5MnWS47fP3z4QGvWrKF9+\\/bRz58\\/bffAMaSmplL\\/\\/v2pa9euhOf4Kwr+4yDc5d69e5yUlMRikHnJkiX8\\/PnzP65SDBp\\/\\/fqVy8rKeMaMGfi3H9NHeEbeunUrC2\\/EAiL+9euX\\/Pz48YMFpCxg5SFDhphk0IbwTpyfn88CbH769ClfvHiRp0yZwi1atGDhvbhJkyYsPC2vXLmSHz9+7Phcqm+4Pn36dClXp04dky60tWzZMn7x4oVjG9aTV69e5eHDh3P9+vVN7aDPUVFRvGfPHhZQB57VKu\\/X7+RFx3fv3s3CG0nDxsXFsfAyYVMLOLKzs22DKDwqHzt2zFVvaWkpC09pkxs\\/fjzfunVLygHyb9++cVVVFa9fv547duwo7xcel5s2bSoBEqGJqw5MlMzMTI6NjeXo6GibroSEBL58+bKrvLqAfmzYsIFHjhzJvXv3trWD9s+ePatu\\/6vqsANbXl7OM2fOlF4Fsx8eQbzKuLq6OmyGXL58eUCf8rS9evXi06dPu+qEZ542bZpt8I3AKmEAA0+4ePFi6WGVDhFisHilc3FxsbrVVufk5Eg9IixiEROb9DVq1Ig3btzIIuywyRlPiBBGTi5MTKc+x8fH84ULF4wif81x2IHNy8tjwKIGFfXQoUNZLHbCZsQVK1bI8MOoE57ozJkzrjqfPXvmOPhOwKIRQIvXslgomZ4N0AFkTACnImJ4nj17Nu\\/cuZMHDhxokkV\\/J0yYEPDoTvI4t3\\/\\/fh49ejQfOXKEFy1aZGtDxNMaWDfj\\/e7827dvecGCBbY4q1mzZrxlyxYZc\\/5OPtRroQKL+NIIOY7dgEXf3r9\\/zxkZGWyNRxH+YKI6FQCblpYmoQRsiOuNOkXmgvfu3csIbZzKmzdvpM65c+cy1gYIMYzyONbAOlkuiHNitc5itWozKGI+vDrv3LkTRCv\\/\\/RavgIWX3bVrVyA+V+AA4KysLBbpMlvnFbAiBSehtsagkAWMiKmdChZ9Y8aMYawLPn\\/+rIF1MlIo52DM3NxcHjVqlITW6knatWsnX21uniQUnUrGK2ChD2HBoEGDbJNywIABfOnSJdWlQK2AffjwISO+d8poiJwsnzhxIiCjDrBoW716NYvUHBcWFsoMgPawyjq1rK9fvy7jLKxmkWLp2bOnaVDhSebNm+eaCqqNei+BxVti3LhxpmeDp23Tpo2ckNbnMAKLybp9+\\/ZAtkF5aKS4MNlFbtkkDl1ID65bty6QntPAmkwU2hfkNmHUsWPHyjSN2wrczZOEpvVfKS+BRW5VJOhtwOKNgjgdYYOxGIHF+du3b0s7KVhVLTY32JoiQ\\/gxadIkmRZEuypNpmRUrWNYo8WDOIYngGFXrVrFWCQA4G3btnGHDh1MAwtPghRUsMnyIFTLW7wEFn3HIkrBYqyRvsNGhbFYgUVeF\\/dhI8IoK7Z8edOmTTJOhTzi4Tlz5sjYWG28aGCNlq3F8Y4dO+QOEfKeysOUlJTIxYJxUHAstg4dY71aqGcvgUWmYP78+SbY1DNi9wuZEmOxAotr2CyAR1Vyqsakh91QYMuJEyfyoUOHAhkEDaw0Te3+PHnyRG4\\/Lly4UC4qVGvYNsWCwepJxP673DWyeiIlF0rtJbDYsp01a5YNNrw9xO8n5Gvb+AxOwAJ65G6t26xt27Zl8VsB\\/vTpk4xpkb+9e\\/duoDkNbMAUoR8cPHiQxS+hpCdAKGAsbp4EmQSsev9U8RJYpKewEFJeUdXIghw4cMD2SE7A4i109OhR2zYrFqbp6eky\\/QUd+C0EJr4q\\/0dg\\/wEAAP\\/\\/HSpNQQAABqtJREFU7VhrSBZNFF6zTMnU+mFGRiUYaURkJVhWiJmGGkJQ3rpR9iMy6KIGJhgI2a9ILAoDFSPqhxcwkvKCQSVdflSooYiVhZZQllZWauebZ\\/hm2X133zUr3taYgWX3fWfOmTPPeebMOaPQH2z9\\/f20f\\/9+2rlzJ7W1tRk0f\\/z4kTIzM2natGmkKIr6+Pn5UXFxMY2MjBhkfuWP7Oxsmjp1qqofcy1dupRqamqcqnv58iWlpqbqZCCXmJhIDx8+dCp3\\/\\/592rRpk0Fu+fLlVFtba5A7evQo7d69mzo6OnR9r169ovT0dIOeJUuW0Lp162j79u10+\\/ZtnQzwOnTokEFm1apVVFdXpxv7r\\/xQ\\/uRCqqurKSwsjGbMmEFz586l+fPn657AwECaOXMmubm56UDG75SUFGptbf0j5riSsLdu3aI1a9bo1gOix8XFUUtLi2E9zgg7NjbGNy0w025mbDxPT0\\/Ky8ujgYEBnT5JWB0cE\\/vx6dMnOnLkCEVHR9Pp06eprKzM9CkpKaGYmBgDaUHmy5cvT2xSJ6NdSdjy8nJavHixjmTTp0+nkydP0ocPHwwWOiMsBj5+\\/JgSEhJ0usTpUFVVRT9+\\/NDpk4TVwTGxH42NjRQbG8vJCkcNDw+bPl++fKHz58\\/TokWLdI6ZMmUKHThwgHA0O2vv3r2jBw8e0JMnT2hoaMjZMHIVYd+\\/f89tdkxxNm\\/eTPfu3TMQDAZbEfb79++Un59Pvr6+OmwyMjLo+fPnhvVKwhog+bk\\/vn79SidOnOCEbWhoGFcI+W1SUpLOKSKSOMszm5ubeT7p7+9PAQEBtG\\/fPqcphKsIixx19erVunXMmTOHLly4QMDErIGwu3btMuSwYizwi4yMVHVC36VLl2h0dFQMUd+SsCoUE\\/tAMRAVFcULru7u7nGFAXRBQQHNmjVLdQwIi3wNaUVvb69OR19fH9ft4eGhjkeefOrUKdNIe+zYMULE1uaCKF5wrDprL168oOTkZJ0M5HFEmxVdKCAPHz5MXl5eqgwiY1ZWFvX09Dibhq8PxdWzZ89MxwwODvJCSqx1y5Yt9OjRI9Ox2BQHDx5U5xfrRR1x48YNU5nJ\\/udvF10oBBA1vL29eZSFI3+m3bx5kyIiIgxgh4aGEoo3bQNhUMQIh4g3biQcj8pv377xmwgxRryRgly9elWrVveNqn3r1q2GOTZu3Eh37tzRjUVFjyiOaC\\/0I489d+4c4aYEBZRZe\\/PmDY+uZjrFeOSp165do2XLlvFiq7CwkJBGmTWkXkgXhA3iPd6NiJmuyfLfbxEW0TQ3N5ffBKDSt3KEIyD19fW0du1aA9iIskgXcF0kHN\\/V1UXbtm0zjM3JySHktdp29+5dXvgJ54k3CqHjx4\\/T27dvtcP5N0iCgi8kJMQwB67ccA115coVKi0t5USF3T4+PrxwxG0IrvGampro8+fPpnkrJkFOf\\/HiRQoODuZRGbbj5DBrr1+\\/ph07dvANjVsIx2JLyDimD2KtCB4o+pBj\\/2vtlwl7\\/fp1ngYAHHH8ghSINLi7rKys5E7SAoYjDI7HkYgIgvECZO0b1zgLFizgRz4iFlKIiooKQvQV4zZs2MBJAlIjciFvxPEZFBTkVC9ItnLlSkpLSyNsmKdPn\\/LUBPeo8+bNM9zdYi5sRBz7s2fP5hEV104rVqygvXv38kjY2dnJr5tQMJk12HbmzBlav349l3d3d+drwPUe7ktxpGNzahvWhML07Nmzhg2GdKOoqIji4+Np4cKFJFIHgYuwGRstPDyc9uzZY7i\\/1c412b7dYDBb5IQbixgKy7cURiadLCOvwqKkwoisMEcrzOFqP6Zix5sCWcgxx6h9jh+Qgw48zMlcpr29XWFXPwojtMKIpzByKsxhXI\\/Qy4oThUUkR3Xqb+hiVT3XC1thC9tICuTGgwI24cH6MC\\/Wh7d2jepE\\/39gjSzy8nXjWzsHbGGbVmH5OH9rZSGDhjlgp2iwEzbjGW+tsBNrhX5g9i+0Xybs31g8HM4iGScIiKJ15N+wR87pegQmFWFdD4+c0W4ISMLazSPSHksEJGEt4ZGddkNAEtZuHpH2WCIgCWsJj+y0GwKSsHbziLTHEgFJWEt4ZKfdEJCEtZtHpD2WCEjCWsIjO+2GgCSs3Twi7bFEQBLWEh7ZaTcEJGHt5hFpjyUCkrCW8MhOuyEgCWs3j0h7LBGQhLWER3baDQFJWLt5RNpjiYAkrCU8stNuCEjC2s0j0h5LBCRhLeGRnXZDQBLWbh6R9lgiIAlrCY\\/stBsC\\/wFYRRYucL8SkgAAAABJRU5ErkJggg==\\\",\\\"user_file_name\\\":\\\"Screenshot 2020-10-02 at 7.png\\\",\\\"file_name\\\":\\\"Dak_65_2020_10_0316016992462326598065.png\\\",\\\"attachment_type\\\":\\\"image\\/png\\\",\\\"file_size_in_kb\\\":\\\"7.10 KB\\\",\\\"url\\\":\\\"https:\\/\\/pmo.nothibs.tappware.com\\/api\\/content\\/view?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiJ9.eyJleHAiOjE2MDE3ODU2NDYsImlhdCI6MTYwMTY5ODY0NiwianRpIjoiTVRZd01UWTVPRFkwTmc9PSIsImlzcyI6Imh0dHA6XC9cL25vdGhpYnMudGFwcHdhcmUuY29tXC8iLCJuYmYiOjE2MDE2OTg2NDYsImRhdGEiOnsiZmlsZSI6IlJWTkZKbGxIdVwvTTk1dVVzVWhJWUgyY2ZuMVBOaWpOaVVmcnVJcVwvUUw0elhmaDMzYVZwZllpSTZnbmlvajBvcWI2QnBvUWdEa1R3RlE5NlJxc3UwVUJScWR6Ymd1TmRBMktMS2NOVDhoTjFxWnAwcUdrS2hMSFdSSU16VTg0elBWOUJjTFVCQ1BWUjRNaTZTT0tEM0dpNDVhRjc3U3hUQmpFVEM3ZnZqcVJIbGtPWXVmdzEyUGhFOWxWamFvaExsIiwiZGVzaWduYXRpb24iOiJlS2xodnlWZUVsbHZrMWF1OW42RTZiS2ZodHRJcVBaQnlSQVpjVytwTTVYNXRZbmdOTVgrWTBcLytBd1loMEZzbjNRSXM4RjN5bGRKbmRXcGRocTVEV3c9PSJ9fQ.vhr-iL8SDx-kRxiCPVtGbeX5ucCJ6OYDeuv10n0WaflsksaIAUn9Oh_fwJR1pEgsJiTqJq0IDBjlVBk_gFWrVg\\\"}\"}}}");

                IRestResponse response = client.Execute(request);


                

                var responseJson = response.Content;
                responseJson =  System.Text.RegularExpressions.Regex.Replace(responseJson, "<pre.*</pre>", string.Empty, RegexOptions.Singleline);
                NothiOnuchhedSaveResponse nothiOnuchhedSaveResponse = JsonConvert.DeserializeObject<NothiOnuchhedSaveResponse>(responseJson);
                return nothiOnuchhedSaveResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }
        public class FileInfo
        {
            public int id { get; set; }
            public string img_base64 { get; set; }
            public string user_file_name { get; set; }
            public string file_name { get; set; }
            public string attachment_type { get; set; }
            public string file_size_in_kb { get; set; }
            public string url { get; set; }
        }
        public class Onuchhed
        {
            public string nothi_id { get; set; }
            public string nothi_office { get; set; }
            public string note_id { get; set; }
            public string id { get; set; }
            public string note_description { get; set; }
            public string attachments { get; set; }
        }
        
        protected string GetAPIVersion()
        {
            return ReadAppSettings("api-version") ?? DefaultAPIConfiguration.DefaultAPIversion;
        }
        protected string ReadAppSettings(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }


        protected string GetAPIDomain()
        {
            return ReadAppSettings("api-endpoint") ?? DefaultAPIConfiguration.DefaultAPIDomainAddress;
        }

        protected string GetNoteOnuchhedSaveEndPoint()
        {
            return DefaultAPIConfiguration.NoteOnuchhedSaveEndPoint;
        }
    }
}
