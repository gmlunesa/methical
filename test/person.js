//Require the dev-dependencies
let chai = require("chai");
let chaiHttp = require("chai-http");
let should = chai.should();

chai.use(chaiHttp);

const url = "localhost:3000";
//Our parent block
describe("Person", () => {
  /*
   * Test the /GET route
   */
  describe("/GET person", () => {
    it("it should GET proper person data", (done) => {
      chai
        .request(url)
        .get("/api/person")
        .end((err, res) => {
          res.should.have.status(200);
          res.body.should.be.a("object");
          res.body.id.should.be.a("string");
          res.body.name.should.be.a("object");
          res.body.name.first.should.be.a("string");
          res.body.name.last.should.be.a("string");
          res.body.city.should.be.a("string");
          res.body.photo.should.be.a("string");
          res.body.hobbies.should.be.a("array");
          res.body.traits.should.be.a("array");

          done();
        });
    });
  });

  describe("/GET person basic", () => {
    it("it should GET proper basic person data", (done) => {
      chai
        .request(url)
        .get("/api/person")
        .end((err, res) => {
          res.should.have.status(200);
          res.body.should.be.a("object");
          res.body.id.should.be.a("string");
          res.body.name.should.be.a("object");
          res.body.name.first.should.be.a("string");
          res.body.name.last.should.be.a("string");
          done();
        });
    });
  });
});
