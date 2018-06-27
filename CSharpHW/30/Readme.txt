1. Run cmd.exe as administrator
2. Set "netsh http show urlacl" to got [DOMAIN]\[username]
3. Set "netsh http add urlacl url=http://+:8000/ user=[DOMAIN]\[username]"
4. Start Host
5. Start Client