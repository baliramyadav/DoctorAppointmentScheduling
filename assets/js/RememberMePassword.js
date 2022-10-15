
        function showPass() {
            var cookies = document.cookie;
            var allcookie = cookies.split(";");
               for (ctr = 0; ctr < allcookie.length; ctr++) 
                  {
                var dt = allcookie[ctr];
                var str = dt.split("=");
                   if (str[0].trim() == document.getElementById("txtEmail").value.trim()) {
                       document.getElementById("txtPassed").value = str[1];
                    break;
                }
            }
        }
        function showBoth() {
            var cookies = document.cookie;
            var allcookie = cookies.split(";");
            for (c = 0; c < allcookie.length; c++) 
            {
                var a = allcookie[c];
                var v = a.split("=");
                if (v[0].trim() == "erplastid")
                    document.getElementById("txtEmail").value = v[1];
                if (v[0].trim() == "erplastpass")
                {
                    document.getElementById("txtPassed").value = v[1];
                    break;
                }

            }
        }
