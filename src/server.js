var cors = require("cors");
const docs = require("./docs/info");
const express = require("express");
const favicon = require("serve-favicon");
const helmet = require("helmet");
const path = require("path");
const swaggerUI = require("swagger-ui-express");
const utils = require("./utils/utils");

require("dotenv").config();

const personRoute = require("./routes/person");

// Create express server
const create = async () => {
  const app = express();
  app.use(favicon(path.join(__dirname, "../public", "favicon.ico")));

  // Use helmet
  app.use(helmet());

  // Enable all CORS Requests
  app.use(cors());

  // Root route
  // app.get("/", async (req, res) => {
  //   return res.sendFile(path.join(__dirname, "../public/client.html"));
  // });

  // Routes
  app.use("/api/person", personRoute);

  // Swagger docs
  app.use(
    "/",
    swaggerUI.serve,
    swaggerUI.setup(docs.swaggerInfo, docs.swaggerOptions)
  );

  // Error handlers
  app.use(utils.logErrors);
  app.use(utils.clientError404Handler);
  app.use(utils.clientError500Handler);
  app.use(utils.errorHandler);

  return app;
};

module.exports = {
  create,
};
