const data = require("../data/dataList.js");
const express = require("express");
const { generateData } = require("../utils/utils");
const MethicalPerson = require("../models/methicalperson");
const { nanoid } = require("nanoid");

// Set up router
const router = express.Router();

const getRandomPerson = async () => {
  const docCount = await MethicalPerson.estimatedDocumentCount();
  const rand = Math.floor(Math.random() * docCount);
  const randomPerson = await MethicalPerson.findOne().skip(rand);

  return JSON.parse(JSON.stringify(randomPerson));
};

router.get("/", async (req, res) => {
  try {
    const randomPerson = await getRandomPerson();
    randomPerson.id = nanoid();
    randomPerson.hobbies = generateData(data.hobbies, 3);
    randomPerson.traits = generateData(data.traits, 3);
    randomPerson.photo = generateData(data.photos, 1)[0];
    res.json(randomPerson);
  } catch (error) {
    res.send(500);
  }
});

router.get("/basic", async (req, res) => {
  try {
    const randomPerson = await getRandomPerson();
    res.json(randomPerson);
  } catch (error) {
    res.send(500);
  }
});

module.exports = router;
