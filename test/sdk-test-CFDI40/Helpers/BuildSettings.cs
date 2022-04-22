using System;
using System.IO;

namespace Test_SW.Helpers
{
    class BuildSettings
    {
        public string Url = "http://services.test.sw.com.mx";
        public string User = "pruebas_ut@sw.com.mx";
        public string Password = "swpass";
        public string Pfx = Convert.ToBase64String(File.ReadAllBytes("Resources/CertificadosDePrueba/EKU9003173C9.pfx"));
        public string PfxPassword = "swpass";
        public string Token = @"T2lYQ0t4L0RHVkR4dHZ5Nkk1VHNEakZ3Y0J4Nk9GODZuRyt4cE1wVm5tbXB3YVZxTHdOdHAwVXY2NTdJb1hkREtXTzE3dk9pMmdMdkFDR2xFWFVPUXpTUm9mTG1ySXdZbFNja3FRa0RlYURqbzdzdlI2UUx1WGJiKzViUWY2dnZGbFloUDJ6RjhFTGF4M1BySnJ4cHF0YjUvbmRyWWpjTkVLN3ppd3RxL0dJPQ.T2lYQ0t4L0RHVkR4dHZ5Nkk1VHNEakZ3Y0J4Nk9GODZuRyt4cE1wVm5tbFlVcU92YUJTZWlHU3pER1kySnlXRTF4alNUS0ZWcUlVS0NhelhqaXdnWTRncklVSWVvZlFZMWNyUjVxYUFxMWFxcStUL1IzdGpHRTJqdS9Zakw2UGRZbFlVYmJVSkxXa1NZNzN5VUlSUzlJaTYvbi9wczBSRnZGK1NUNUVoM1FNNXZJRUg1Qkx1dXJ1Z09EcHYyQnE4V1dnOHpkczFLdm5MZytxalNBeHdRbmFvb2VhTksrVzhyTTFXU09NbzZVeXMyQ2Q4VC9ncUlqWGZaMFhXSkdmcjJIWlB2Z2RmeFJGNzRkdXh2UHlvdnVhbGN6cGFsRWhSY3BOOWxPc0h4Z2ZJRjBjZEl5WEsvZW0vb0ZxZEJjUGtpRFlWYi9zRDZwZVJFRks0QUpRNkplZ2N4UzVEME40d2RhUHA4c1VUQWJiY1Jvc3NSVFcrRzVyTHNOTWovZlJHQmV6c0lmclE1TXV3aVY3UERtQUo3SjdpTzhuc1R1SGt1R0s0UHUvc3hEZWRtK3U0NExEYUdUVWIxL3NKRE1XY1RlTnNMaENoSFUvVGhaclk2WmNPR2JjUlpib1RPUTN5QUxiU0VEY0NpYmJDcDZHY3pGd0ZJMXcxTEExTnBPdzM.VZBKM8Odz5VdIyhQPZyRaJK1iVLmot-oMf0h69NU4vk";
    }
}
