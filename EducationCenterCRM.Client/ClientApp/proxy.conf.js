const { env } = require("process");

const target = env.ASPNETCORE_HTTPS_PORT
  ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}`
  : env.ASPNETCORE_URLS
  ? env.ASPNETCORE_URLS.split(";")[0]
  : "http://localhost:53334";

const PROXY_CONFIG = [
  {
    context: [
      "/courses",
      "/courses/getbyid",
      "/courses/update",
      "/courses/create",
      "/courses/getbyfilter",
      "/courses/search",
      "/courses/courselvlnames",
      "/courses/alltitles",
      "/courses/getteachers",
      "/topics/alltitles",
      "/studingrequests/add",
      "/identity/registration",
      "/identity/refresh",
      "/identity/login",
      "/identity/getallusers",
      "/identity/getbyfilter",
      "/identity/getallroles",
      "/identity/changeroles",
      "/studingrequests/getallopen",
      "/studingrequests/getallclosed",
      "/studingrequests/getallstydingtypes",
      "/studingrequests/confirmrequest",
      "/students/getbyid",
      "/groups",
      "/groups/getbyid",
      "/groups/update",
      "/groups/create",
      "/groups/getbyfilter",
      "/groups/getallstatuses",
      "/groups/getbyrequest",
      "/groups/groups/getstudents",
      "/teachers",
      "/teachers/allnames",
      "/teachers/getbyid",
      "/teachers/update",
      "/teachers/create",
      "/teachers/getbyfilter",
      "teachers/updateCourses",
    ],
    target: target,
    secure: false,
  },
];

module.exports = PROXY_CONFIG;
