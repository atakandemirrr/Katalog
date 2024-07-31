
function goToHomePage() {
    window.location.href = '/';
}

function openModal(imageSrc) {
    const modal = document.getElementById("myModal");
    const modalImage = document.getElementById("modalImage");
    const buttons = document.querySelectorAll('button');

    modal.style.display = "flex"; // Modal'ı görünür yapar
    modalImage.src = imageSrc;

    // Butonları gizle
    buttons.forEach(button => button.style.display = 'none');
}

function closeModal() {
    const modal = document.getElementById("myModal");
    const buttons = document.querySelectorAll('button');

    modal.style.display = "none"; // Modal'ı gizler

    // Butonları geri göster
    buttons.forEach(button => button.style.display = 'block');
}

window.onclick = function (event) {
    const modal = document.getElementById("myModal");
    if (event.target == modal) {
        closeModal();
    }
}
