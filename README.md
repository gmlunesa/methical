# methical

## About

> Do imaginary people dream of electric sheep?

/mēTHək(ə)l/

Generate a non-existent profile with **methical**. An AI-generated photo, names, residence and description that aren't a part of anyone that has been born on Earth (yet).

This repository contains the backend of the project. If you wish to access the front-end, please visit the [Methical frontend](https://methical.vercel.app/).

### Stack

| <img src="https://upload.wikimedia.org/wikipedia/commons/8/8e/Nextjs-logo.svg" width="100" height="100" alt="NextJS"> | <img src="https://upload.wikimedia.org/wikipedia/commons/e/ee/.NET_Core_Logo.svg" width="100" height="100" alt="NET Core"> | <img src="https://raw.githubusercontent.com/yurijserrano/Github-Profile-Readme-Logos/f994c418a134b58c4aec11152f6a4a33fa89da26/cloud/azure.svg" width="100" alt="Azure"> |
| --------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------- |

- Frontend written with Next.js
- API written with ASP.NET Core
- CI/CD via Github Actions
- Deployed to Azure App Service

### Machine Learning models

| Model            | Citation                                                                        | How it's used in this demo     |
| ---------------- | ------------------------------------------------------------------------------- | ------------------------------ |
| GPT-J 6B         | [Wang et al., 2021](https://github.com/kingoflolz/mesh-transformer-jax)         | 💬 Text generation for the bio |
| StyleGAN2        | [Karras et al., 2020](https://arxiv.org/abs/1912.04958)                         | 💆‍♀️ Generate faces              |
| Stable Diffusion | [Rombach et al., 2022](https://ommer-lab.com/research/latent-diffusion-models/) | 💆‍♀️ Generate faces              |

## Setup

The following are the steps on running the server locally.

Clone the repository.

```sh
git clone https://github.com/gmlunesa/methical-frontend.git
```

This projects uses App secrets to store the HuggingFace API token.

To store secrets locally via the Secret Manager tool,

```sh
dotnet user-secrets init
dotnet user-secrets set "MLPlatform:Token" "XXXXXXXXXXXXX"
```

When deploying to Azure, secrets will need to be stored in the Azure Key Vault.

```sh
az keyvault secret set --vault-name {KEY VAULT NAME} --name "MLPlatform--Token" --value "XXXXXXXXXXXXX"
```

Run the application.

```sh
dotnet run --project Methical
```

## License

[MIT 🌱 Fully open-source](https://github.com/gmlunesa/methical/blob/main/LICENSE)

## Credits

- Favicon is from the open source project [Twemoji](https://twemoji.twitter.com/).

---

Made with 💫✨ by [gmlunesa](https://gmlunesa.com)
