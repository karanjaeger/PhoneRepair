mergeInto(LibraryManager.library, {
  UnityEvent: function (data) {
    // Convert the pointer to a string
    var message = UTF8ToString(data);
    console.log("Being sent")

    // Post the message to the parent context
    window.parent.postMessage({ type: 'UnityEvent', detail: message }, '*');
  },
});
