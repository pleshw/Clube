export async function animateNumberRollElement(logElementQuerySelector, expectedOutput) {
    let entry = {
        numOutput: 0
    }

    await anime({
        targets: entry,
        numOutput: expectedOutput,
        round: 1,
        easing: 'linear',
        update: function () {
            document.querySelector(logElementQuerySelector).innerHTML = entry.numOutput;
        }
    });
}