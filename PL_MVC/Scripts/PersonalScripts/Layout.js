function toggleOptions() {
    const optionsList = document.getElementById('optionsList');

    // Revisar si la lista está visible
    if (optionsList.style.display === 'block') {
        // Si está visible, ocultarla
        optionsList.style.display = 'none';
    } else {
        // Si está oculta, mostrarla
        optionsList.style.display = 'block';
    }
}