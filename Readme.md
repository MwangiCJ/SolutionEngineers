# Hello,
## Thanks for reviewing this code.


The project code is built with C# 's Asp .netcore framework.

To test it, please follow below steps.



### A. Testing on Visual Studio 2019 IDE

**Requirements**
1. Mysql/MariaDB Server

**Steps**
1. Open the IDE and select load project or solution
2. navigate to the location where the project is downloaded and select ms_vooma_account_and_credit.sln
3. Locate the appsettings.json on the project root and modify db connection string
4. Click on start debuggng.
5. On the browser, navigate to http://localhost:28214/swagger (The port may differ)
6. Perform some tests on the different endpoints

### B. Testing from a docker environment
You can also run the project as docker container.
1. Navigate to the where the project is located.
2. Navigate to "\ms-vooma-account-and-credit\ms_vooma_account_and_credit"
3. Locate the appsettings.json on the project root and modify db connection string
3. Run "docker build -t ms-vooma-account-and-credit ."
5. Then "docker run -p 80:80 ms-vooma-account-and-credit"
6. On the browser, navigate to http://<hostip>:<Port>/swagger
7. Test
