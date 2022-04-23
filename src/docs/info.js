const swaggerInfo = {
  openapi: "3.0.3",
  info: {
    title: "methical API",
    description: "API that generates mythical people and imaginary data",
    version: "1.0.0",
    contact: {
      name: "@gmlunesa",
      email: "gmlunesa@gmail.com",
      url: "https://gmlunesa.com",
    },
  },
  components: {
    schemas: {
      Person: {
        type: "object",
        properties: {
          id: {
            type: "String",
            description: "Unique id",
            example: "Cf95OMJy8G69THpM9xFjH",
          },
          name: {
            type: "object",
            properties: {
              first: {
                type: "String",
                description: "First name",
                example: "Kris",
              },
              last: {
                type: "String",
                description: "Last name",
                example: "Kelvin",
              },
            },
          },
          city: {
            type: "String",
            description: "City of current residence",
            example: "Tokyo, Japan",
          },
          hobbies: {
            type: "array",
            description: "Array of hobbies",
            example: ["Knitting", "Crocheting", "Painting"],
          },
          traits: {
            type: "array",
            description: "Array of traits",
            example: ["Introverted", "Shy", "Quiet"],
          },
          photo: {
            type: "String",
            description: "URL to a photo",
            example:
              "https://upload.wikimedia.org/wikipedia/en/5/54/Solyaris_ussr_poster.jpg",
          },
        },
      },

      PersonBasic: {
        type: "object",
        properties: {
          id: {
            type: "String",
            description: "Unique id",
            example: "Cf95OMJy8G69THpM9xFjH",
          },
          name: {
            type: "object",
            properties: {
              first: {
                type: "String",
                description: "First name",
                example: "Kris",
              },
              last: {
                type: "String",
                description: "Last name",
                example: "Kelvin",
              },
            },
          },
          city: {
            type: "String",
            description: "City of current residence",
            example: "Tokyo, Japan",
          },
          photo: {
            type: "String",
            description: "URL to a photo",
            example:
              "https://upload.wikimedia.org/wikipedia/en/5/54/Solyaris_ussr_poster.jpg",
          },
        },
      },
    },
  },
  servers: [
    {
      url: "https://methical-api.herokuapp.com/", // url
      description: "Heroku Server", // name
    },
    {
      url: "http://localhost:3000/", // url
      description: "Local Server", // name
    },
  ],

  tags: [
    {
      name: "Person",
      description: "Generates person data",
    },
  ],

  paths: {
    "/api/person": {
      get: {
        tags: ["Person"],
        description: "Get Person", // operation's desc.
        operationId: "getPerson", // unique operation id.
        parameters: [], // expected params.
        // expected responses
        responses: {
          // response code
          200: {
            description: "Person data is obtained",
            content: {
              // content-type
              "application/json": {
                schema: {
                  $ref: "#/components/schemas/Person",
                },
              },
            },
          },
        },
      },
    },
    "/api/person/basic": {
      get: {
        tags: ["Person"],
        description: "Get basic person details", // operation's desc.
        operationId: "getPersonBasic", // unique operation id.
        parameters: [], // expected params.
        // expected responses
        responses: {
          // response code
          200: {
            description: "Basic person data is obtained",
            content: {
              // content-type
              "application/json": {
                schema: {
                  $ref: "#/components/schemas/PersonBasic",
                },
              },
            },
          },
        },
      },
    },
  },
};

const swaggerOptions = {
  customCss: ".swagger-ui .topbar { display: none }",
  customSiteTitle: "methical | An API for mythical people",
};

module.exports = {
  swaggerInfo,
  swaggerOptions,
};
