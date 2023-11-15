const confirmEmailCopyButton = document.querySelector("#email_confirmation__copy");
const confirmEmailTokenInput = document.querySelector("#email_confirmation__token");
const confirmEmailTokenToEmailInput = document.querySelector("#email_confirmation__tokenToEmail");

confirmEmailCopyButton.addEventListener("click", () => {
    console.log(confirmEmailTokenInput.value)
    confirmEmailTokenToEmailInput.value = confirmEmailTokenInput.value 
})