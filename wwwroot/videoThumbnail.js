export function loadPopover(elementId, videoTitle, channelTitle, duration) {
    new bootstrap.Popover(document.getElementById(elementId),
        {
            title: videoTitle,
            trigger: 'hover focus',
            sanitize: true,
            placement: 'right',
            customClass: 'video-thumbnail-popover',
            html: true,
            content: `<ul>
                <li>Canal: ${channelTitle}</li>
                <li>Duração: ${duration}</li>
            </ul>`,
        });
}

export function disposePopover(elementId) {
    const elementPopover = document.getElementById(elementId);

    if (elementPopover) {
        const popoverInstance = bootstrap.Popover.getInstance(elementPopover);
        if (popoverInstance) {
            popoverInstance.dispose();
        }
    }
}
